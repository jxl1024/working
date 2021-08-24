using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Models.APIModel;

namespace Working.Service
{
    public interface IUserService
    {
        UserRole Login(string userName, string password);
    }
}
