using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Models.DBModels;

namespace Working.Models.APIModel
{
    public class UserRole : User
    {
        /// <summary>
        /// 用户角色
        /// </summary>        
        public string RoleName { get; set; }
    }
}
