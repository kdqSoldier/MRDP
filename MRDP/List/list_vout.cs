using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class list_vout
    {
        public string point;
        public List<Listv_out> list_dat;
        public list_vout(string point, List<Listv_out> list_dat)
        {
            this.point = point;
            this.list_dat = list_dat;
        }
    }
}
