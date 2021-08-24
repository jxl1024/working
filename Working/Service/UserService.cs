using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Models.APIModel;
using Working.Repository;

namespace Working.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserRole Login(string userName, string password)
        {
            UserRole userRole = _userRepository.Login(userName, password);
            return userRole;
        }
    }
}
