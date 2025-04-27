using SMS.APIModel.DTOs;
using SMS.Common;
using SMS.Service.Interface;
using SMS.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> GetUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUser(username, password);
            if (user == null)
                throw new UserNotValidException();

            return new UserDto { Id = user.Key, Description = user.Description };
        }
    }
}
