using Azure;
using Polly;
using Polly.Retry;
using Polly.Timeout;
using SMS.APIModel.RequestModels;
using SMS.Domain.Entities;
using SMS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.Service
{
    public class SmsService : ISmsService
    {
        private readonly HttpClient _httpClient;
        private readonly IUserService _userService;
        private readonly ILogService _logService;
        private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;
        private int _retryCount;
        public SmsService(HttpClient httpClient, IUserService userService, ILogService logService)
        {
            _httpClient = httpClient;
            _userService = userService;
            _logService = logService;

            // --- SET A BASIC CLIENT TIMEOUT (safe default) ---
            _httpClient.Timeout = TimeSpan.FromSeconds(60);

            // Define Timeout Policy
            var timeoutPolicy = Policy
                .TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10), TimeoutStrategy.Optimistic);

            // Define Retry Policy
            var retryPolicy = Policy
                            .Handle<HttpRequestException>()
                            .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                            .WaitAndRetryAsync(
                                retryCount: 3,
                                sleepDurationProvider: _ => TimeSpan.FromSeconds(10),
                                onRetry: (outcome, timespan, attempt, context) =>
                                {
                                    _retryCount = attempt;
                                });


            // Define Fallback Policy
            var fallbackPolicy = Policy<HttpResponseMessage>
                .Handle<Exception>()
                .FallbackAsync(
                    fallbackAction: (cancellationToken) =>
                    {
                        var fallbackResponse = new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable)
                        {
                            Content = new StringContent("Fallback response: Service is unavailable.")
                        };
                        _retryCount = 4;
                        return Task.FromResult(fallbackResponse);
                    }
                );

            // Combine Policies: Fallback > Retry > Timeout
            _retryPolicy = fallbackPolicy.WrapAsync(retryPolicy.WrapAsync(timeoutPolicy));
        }

        public async Task<string> SendSms(SendSmsRequestModel request)
        {
            _retryCount = 0;
            var user = await _userService.GetUserAsync(request.Username, request.Password);
            var log = new Log(request.To, request.Text, DateTime.Now, user.Id);
            

            string url = $"https://sms.magfa.com/api/http/sms/v1?service=enqueue" +
                    $"&username=naft_75943&password=HDAKJV0RImICUBF6&domain=odcc" +
                    $"&from=+98300075943&to={request.To}&text={request.Text}";

            // Call Magfa
            var response = await _retryPolicy.ExecuteAsync(() => _httpClient.GetAsync(url));
            var responseBody = await response.Content.ReadAsStringAsync();

            // Log SMS
            log.StatusCode = (int)response.StatusCode;
            log.Response = responseBody;
            log.SentAt = DateTime.UtcNow;
            log.RetryCount = _retryCount;

            await _logService.AddAsync(log);

            return responseBody;
        }
    }
}
