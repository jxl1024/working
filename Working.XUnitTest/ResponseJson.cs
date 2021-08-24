using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Working.XUnitTest
{
    public class ResponseJson
    {
        public int result
        { get; set; }
        public string message
        { get; set; }

        public dynamic data
        { get; set; }
    }
}
