using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Working.Models.APIModel;
using Working.Repository;
using Working.Service;
using Xunit;

namespace Working.XUnitTest
{
    public class UserServiceTest
    {
        [Trait("用户服务层", "UserService")]
        [Fact]
        public void Login_Default_Return()
        {
            var userRepository= new Mock<IUserRepository>();
            var userService = new UserService(userRepository.Object);

            var user = new UserRole() 
            {
                ID = Guid.NewGuid(),
                Name = "管理员",
                DepartID = Guid.NewGuid(),
                Password = "123456",
                RoleID = Guid.NewGuid(),
                RoleName = "Leader",
                UserName = "admin"
            };
            userRepository.Setup(p => p.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            var userRole = userService.Login("admin", "123456");

            Assert.NotNull(userRole);

        }

        [Fact]
        public void Login_Null_Return()
        {
            var userRepository = new Mock<IUserRepository>();
            var userService = new UserService(userRepository.Object);
            UserRole user = null;
            userRepository.Setup(p => p.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            var userRole = userService.Login("admin", "123456");

            Assert.Null(userRole);

        }
    }
}
