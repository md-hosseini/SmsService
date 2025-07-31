using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Common
{
    public static class AppSettingFactory
    {
        private static IConfiguration _configuration;
        public static AppSetting AppSetting { get; private set; }

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
            AppSetting = new AppSetting
            {
                SMS_Base_Url = _configuration["SMS:Url"],
                SMS_Service = _configuration["SMS:Service"],
                RetryCount = Convert.ToInt16(_configuration["RetryCount"]),
                ErrorCodes =
        _configuration["SMS:ErrorCodes"]
        ?.Split(',', StringSplitOptions.RemoveEmptyEntries)
        .Select(code => code.Trim())
        .ToList() ?? new List<string>(),
                DefaultDomain = _configuration["SMS:DefaultDomain"],
                DefaultFrom = _configuration["SMS:DefaultFrom"],
                DefaultPassword = _configuration["SMS:DefaultPassword"],
                DefaultUserName = _configuration["SMS:DefaultUserName"],
            };
        }
    }

    public class AppSetting
    {
        public string SMS_Service { get; set; }
        public string SMS_Base_Url { get; set; }
        public int RetryCount { get; set; }
        public List<string> ErrorCodes { get; set; } = new List<string>();
        public string DefaultUserName { get; set; }
        public string DefaultPassword { get; set; }
        public string DefaultFrom { get; set; }
        public string DefaultDomain { get; set; }
    }
}
