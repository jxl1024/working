using Microsoft.AspNetCore.Mvc;
using Moq;
using Working.Controllers;
using Working.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using Xunit;
using Working.Models.APIModel;

namespace Working.XUnitTest
{
    public class LoginControllerTest
    {
        Mock<IUserService> _userService;
        LoginController _loginController;


        public LoginControllerTest()
        {
            _userService = new Mock<IUserService>();
            _loginController = new LoginController(_userService.Object)
            {
                ControllerContext = new ControllerContext()
            };

            var authServiceMock = new Mock<IAuthenticationService>();
            authServiceMock
                .Setup(_ => _.SignInAsync(It.IsAny<HttpContext>(), It.IsAny<string>(), It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.FromResult((object)null));

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock
                .Setup(_ => _.GetService(typeof(IAuthenticationService)))
                .Returns(authServiceMock.Object);

            var claims = new Claim[]
              {
                    new Claim(ClaimTypes.Sid,"1"),

              };
            _loginController.ControllerContext.HttpContext = new DefaultHttpContext()
            {
                RequestServices = serviceProviderMock.Object,
                User = new ClaimsPrincipal(new ClaimsIdentity(claims))
            };
        }


        #region 登录测试
        /// <summary>
        /// 测试正确用户名密码登录
        /// </summary>
        [Fact]
        public void Login_Default_Return()
        {
            // u.Login("admin", "123") 准备数据，最终和控制器的Index方法传入的参数进行比较，两者相同
            // Returns：返回的数据
            _userService.Setup(u => u.Login("admin", "123")).Returns(new UserRole() { ID = Guid.NewGuid(), Name = "张三", RoleName = "Leader", DepartID = Guid.NewGuid(), 
                UserName = "admin", Password = "12323" });

            var result = _loginController.Index("admin", "123", null);
            var redirectResult = Assert.IsType<RedirectResult>(result);

            Assert.Equal("/home/index", redirectResult.Url);

        }
        /// <summary>
        /// 测试空用户
        /// </summary>
        [Fact]
        public void Login_NullUsert_ReturnView()
        {
            // 返回数据为null
            _userService.Setup(u => u.Login("admin", "123")).Returns(value: null);
            var result = _loginController.Index("admin", "123", null);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }
        #endregion
    }
}
