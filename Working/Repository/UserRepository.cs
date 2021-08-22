using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Context;
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

        public User Login(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
