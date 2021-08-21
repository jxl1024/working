using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Working.Models.DBModels
{
    public class WorkItem : BaseModel
    {
        /// <summary>
        /// 备注
        /// </summary>
        public string Memos { get; set; }

        /// <summary>
        /// 工作记录日期
        /// 跟创建日期可能不相同
        /// </summary>
        public string RecordDate { get; set; }

        public string WorkContent { get; set; }
    }
}
