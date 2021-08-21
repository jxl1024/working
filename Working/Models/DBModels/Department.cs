using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Working.Models.DBModels
{
    public class Department : BaseModel
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartName { get; set; }

        /// <summary>
        /// 父级部门ID
        /// </summary>
        public Guid? ParentID { get; set; }
    }
}
