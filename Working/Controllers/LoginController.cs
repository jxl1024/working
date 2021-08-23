using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Working.Models.APIModel;
using Working.Models.DBModels;
using Working.Repository;

namespace Working.Controllers
{
    /// <summary>
    /// 根据角色设置权限
    /// 只有Employee，Leader，Manager这三个角色的权限才能访问
    /// </summary>
    [Authorize(Roles = "Employee,Leader,Manager")]
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// 登录页面可以匿名访问
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            // 没有通过验证，将访问的网址保留下来
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.returnUrl = returnUrl;
            }
            return View();
        }

        /// <summary>
        /// 可以匿名访问
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(string userName,string password, string returnUrl)
        {

            UserRole userRole = _userRepository.Login(userName, password);

            
            if(null != userRole)
            {
                var claims = new Claim[]
                {
                   new Claim(ClaimTypes.Role,userRole.RoleName),
                    new Claim(ClaimTypes.Name,userRole.Name),
                     new Claim(ClaimTypes.Sid,userRole.ID.ToString())
                };

                // 登录成功
                // 会把claims通过一定的加密存储到Cookie中，第二次访问的时候把Cookie带到服务端
                // 服务端把加密内容解密出来进行验证，有没有权限
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(claims, "claim")));
                // 如果returnUrl为空，则跳转到主页，否则跳转到原来访问的页面
                return new RedirectResult(string.IsNullOrEmpty(returnUrl) ? "/home/index" : returnUrl);
            }
            else
            {
                ViewBag.error = "用户名或密码错误";
                return View();
            }

            #region 测试代码
            //// 判断用户名和密码
            //if(userName=="admin" && password=="123456")
            //{
            //    var claims = new Claim[]
            //    {
            //       new Claim(ClaimTypes.Role,"Leader"),
            //        new Claim(ClaimTypes.Name,"jxl"),
            //         new Claim(ClaimTypes.Sid,"1")
            //    };

            //    // 登录成功
            //    // 会把claims通过一定的加密存储到Cookie中，第二次访问的时候把Cookie带到服务端
            //    // 服务端把加密内容解密出来进行验证，有没有权限
            //    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
            //        new ClaimsPrincipal(new ClaimsIdentity(claims,"claim")));
            //    // 如果returnUrl为空，则跳转到主页，否则跳转到原来访问的页面
            //    return new RedirectResult(string.IsNullOrEmpty(returnUrl) ? "/home/index" : returnUrl);
            //}
            //else
            //{
            //    ViewBag.error = "用户名或密码错误";
            //    return View();
            //} 
            #endregion

        }

        /// <summary>
        /// 测试
        /// 程序启动会访问Login控制器下面的Test方法，该方法
        /// 没有角色，会跳转到Login登录页面
        /// 将路由规则的action修改为Test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
