using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Models.Enum;
using Working.Repository;

namespace Working.Controllers
{
    public class DepartmentController : BaseController
    {

        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取全部带父级部门的部门
        /// </summary>
        /// <returns></returns>

        [HttpGet("getallpdepartment")]
        public IActionResult GetAllPDepartments()
        {
            try
            {
                //_logger.LogInformation("获取全部带父级部门的部门");
                var list = _departmentRepository.GetAllPDepartment();
                return ToJson(BackResult.Success, data: list);

            }
            catch (Exception exc)
            {
                //_logger.LogCritical(exc, $"获取全部带父级部门的部门：{ exc.Message}");
                return ToJson(BackResult.Exception, message: exc.Message);
            }
        }

        /// <summary>
        /// 获取全部带父级部门的部门
        /// </summary>
        /// <returns></returns>
        [HttpGet("getalldepartment")]
        public IActionResult GetAllDepartments()
        {
            try
            {
                //_logger.LogInformation("获取全部带父级部门的部门");
                var list = _departmentRepository.GetAllDepartment();
                return ToJson(BackResult.Success, data: list);

            }
            catch (Exception exc)
            {
                //_logger.LogCritical(exc, $"获取全部带父级部门的部门：{ exc.Message}");
                return ToJson(BackResult.Exception, message: exc.Message);
            }
        }
    }
}
