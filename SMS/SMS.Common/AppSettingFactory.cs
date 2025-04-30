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
                SMS_Username = _configuration["SMS:Username"],
                SMS_Password = _configuration["SMS:Password"],
                SMS_Domain = _configuration["SMS:Domain"],
                SMS_From = _configuration["SMS:From"],
                SMS_Service = _configuration["SMS:Service"]
            };
        }
    }

    public class AppSetting
    {
        public string SMS_Service { get; set; }
        public string SMS_Base_Url { get; set; }
        public string SMS_Username { get; set; }
        public string SMS_Password { get; set; }
        public string SMS_Domain { get; set; }
        public string SMS_From { get; set; }
    }
}
