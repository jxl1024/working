using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Context;
using Working.Models.APIModel;
using Working.Models.DBModels;

namespace Working.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public UserRole Login(string userName, string password)
        {
            //User user= _appDbContext.Users.FirstOrDefault(p => p.UserName.ToLower() == userName && p.Password.ToLower() == password);
            //return user;

            //UserRole userRole = new UserRole();
            var query = from u in _appDbContext.Users
                        join r in _appDbContext.Roles
                        on u.RoleID equals r.ID
                        where u.UserName.ToLower() == userName
                        && u.Password.ToLower() == password
                        select new UserRole
                        {
                            ID=u.ID,
                            Name=u.Name,
                            Password=u.Password,
                            RoleID=u.RoleID,
                            UserName=u.UserName,
                            DepartID=u.DepartID,
                            CreateTime=u.CreateTime,
                            CreateUser=u.CreateUser,
                            UpdateTime=u.UpdateTime,
                            UpdateUser=u.UpdateUser,
                            RoleName=r.RoleName
                        };
            UserRole userRole = query.FirstOrDefault();   
            return userRole;
        }
    }
}
