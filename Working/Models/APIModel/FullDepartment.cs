using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Models.DBModels;

namespace Working.Models.APIModel
{
    public class FullDepartment : Department
    {
        /// <summary>
        /// 上级部门名称
        /// </summary>      
        public string PDepartmentName { get; set; }
    }
}
