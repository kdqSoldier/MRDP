using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class List_da
    {
        
        public string num;
        public List< string> point_;
        public  List< string> dat_l;//dist
        public  List< string> dat_r;//Hi
        public  List< string> dat_1=new List<string>();
        public List<string> dat_2 = new List<string>();
        public List<string> dat_3 = new List<string>();
        public List<string> dat_4 = new List<string>();
        public List_da(string num,  List< string> point_,  List< string> dat_l,  List< string> dat_r)
        {
            this.num = num;
            this.point_ = point_;
            this.dat_l = dat_l;
            this.dat_r = dat_r;
        }

    }
}
