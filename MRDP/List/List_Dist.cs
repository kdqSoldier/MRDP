using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class List_Dist
    {
        public string point;
        public List<List_da> data_dist;
       //  List<string> point_, List<string> dist, List<string> equipmentHi
        public List_Dist(string Point, List<List_da> data_dist)
        {
            this.point = Point;
            this.data_dist = data_dist;
        }
    }
}
