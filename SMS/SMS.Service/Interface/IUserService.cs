using SMS.APIModel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.Interface
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string username, string password);
    }
}
