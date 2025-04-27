using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.APIModel.RequestModels
{
    public class CreateLogRequestModel
    {
        public string To { get; set; }
        public string Text { get; set; }
        public int? StatusCode { get; set; }
        public string? Response { get; set; }
        public DateTime? SentAt { get; set; }
        public Guid UserId { get; set; }
    }
}
