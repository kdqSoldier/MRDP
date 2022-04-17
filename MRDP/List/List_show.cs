using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class List_show
    {
        public int val;
        public string point;

        public List_show( int Val,string Point)
        {
            this.val = Val;
            this.point = Point;
        }
        public string Point
        {
            get { return point; }
        }
        public int Val
        {
            get { return val; }
        }
    }
}
