using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Log
    {
        public Log(string to, string text, DateTime requestedAt, Guid userId)
        {
            To = to;
            Text = text;
            RequestedAt = requestedAt;
            UserId = userId;
        }

        public Guid Key { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public int? StatusCode { get; set; }
        public string? Response { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public int? RetryCount { get; set; }
    }
}
