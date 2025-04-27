using SMS.APIModel.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.Interface
{
    public interface ISmsService
    {
        Task<string> SendSms(SendSmsRequestModel request);
    }
}
