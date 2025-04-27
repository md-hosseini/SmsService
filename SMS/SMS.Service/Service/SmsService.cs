using Polly;
using Polly.Retry;
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
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;
        public SmsService(HttpClient httpClient, IUserService userService)
        {
            _httpClient = httpClient;
            _userService = userService;
            _retryPolicy = Policy.Handle<HttpRequestException>() // Handle network-related issues
                            .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode) // Retry on failure HTTP status
                            .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(10));
        }

        public async Task<string> SendSms(SendSmsRequestModel request)
        {
           // var user = await _userService.GetUserAsync(request.Username, request.Password);
            string url = $"https://sms.magfa.com/api/http/sms/v1?service=enqueue" +
                    $"&username=naft_75943&password=HDAKJV0RImICUBF6&domain=odcc" +
                    $"&from=+98300075943&to={request.To}&text={request.Text}";

            // Call Magfa
            var response = await _retryPolicy.ExecuteAsync(() => _httpClient.GetAsync(url));
            var responseBody = await response.Content.ReadAsStringAsync();

            // Log SMS
            var log = new Log
            {
                To = request.To,
                Text = request.Text,
                StatusCode = (int)response.StatusCode,
                Response = responseBody,
                SentAt = DateTime.UtcNow,
              //  UserId = user.Id
            };

            return responseBody;
        }
    }
}
