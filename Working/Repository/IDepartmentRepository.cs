using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Models.APIModel;
using Working.Models.DBModels;

namespace Working.Repository
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// 查询全部部门带父部门
        /// </summary>
        /// <returns></returns>
        List<FullDepartment> GetAllPDepartment();

        /// <summary>
        /// 查询全部部门
        /// </summary>
        /// <returns></returns>
        List<Department> GetAllDepartment();
    }
}
