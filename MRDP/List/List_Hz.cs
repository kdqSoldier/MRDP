using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class List_Hz
    {
        public string point;
        public List< List_da> data_hz ;


        public List_Hz(string Point, List<List_da> data_hz)
        {
            this.point = Point;
            //point_  l  r  2c  归零值
            this.data_hz = data_hz;
        }

    }
}
