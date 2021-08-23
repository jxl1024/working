using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Models.APIModel;
using Working.Models.DBModels;

namespace Working.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        UserRole Login(string userName, string password);
    }
}
