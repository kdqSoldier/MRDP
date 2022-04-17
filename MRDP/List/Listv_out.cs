using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class Listv_out
    {
     
        public string num;
        public List<string> point_;
        public List<string> dat_i;
        public List<string> dat_Zenith;
        public List<string> dat_3;
        public Listv_out(string num, List<string> point_, List<string> dat_i, List<string> dat_Zenith,List<string> dat_3)
        {
            this.num = num;
            this.point_ = point_;
            this.dat_i = dat_i;
            this.dat_Zenith = dat_Zenith;
            this.dat_3 = dat_3;
        }

    }
}
