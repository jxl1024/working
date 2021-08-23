using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Working.Context;
using Working.Models;

namespace Working.Controllers
{
    [Authorize(Roles = "Employee,Leader,Manager")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index page says hello");
            var roles = await _dbContext.Roles.ToListAsync();
            ViewData["Roles"] = JsonConvert.SerializeObject(roles);
            return View();
        }

        /// <summary>
        /// 重新设置的Employee,Manager角色才可以访问
        /// 如果角色是Leader，不能访问该方法
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Employee,Manager")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
