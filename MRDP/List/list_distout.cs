using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class list_distout
    {
        public string point;
        public List<Listdist_out> list_dat;
        public list_distout(string point, List<Listdist_out> list_dat)
        {
            this.point = point;
            this.list_dat = list_dat;
        }
    }
}
