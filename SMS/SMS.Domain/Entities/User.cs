using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class User
    {
        public Guid Key { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public bool IsActive { set; get; }

        public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
    }
}
