using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class List_V
    {
        public string point;
        public List<List_da> data_v;
        public List<string> high;
        // List<string> point_, List<string> v_l, List<string> v_r, List<string> equipmentHi
        public List_V(string Point,List<string>  high,List<List_da> data_v)
        {
            this.point = Point;
            this.high = high;
            this.data_v = data_v;
        }
    }
}
