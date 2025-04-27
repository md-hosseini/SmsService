using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Common
{
    public class UserNotValidException : Exception
    {
        public UserNotValidException() : base ("User is not valid")
        {
            
        }
    }
}
