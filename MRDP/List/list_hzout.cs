using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class list_hzout
    {
         public string point;
        public List<Listhz_out> list_dat;
        public list_hzout(string point, List<Listhz_out> list_dat)
        {
            this.point = point;
            this.list_dat = list_dat;
        }
    }
}
