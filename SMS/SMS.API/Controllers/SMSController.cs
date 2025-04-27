using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.APIModel.RequestModels;
using SMS.Common;
using SMS.Domain.Entities;
using SMS.Service.Interface;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISmsService _smsService;
        private IUnitOfWork _unitOfWork;

        public SMSController(ISmsService smsService, IUnitOfWork unitOfWork)
        {
            _smsService = smsService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> Send(SendSmsRequestModel request)
        {
            try
            {
                var res = await _smsService.SendSms(request);
                return Ok(new
                {
                    Response = res
                });
            }
            catch (UserNotValidException ex)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "An error occurred", Details = ex.Message });
            }
        }
    }
}