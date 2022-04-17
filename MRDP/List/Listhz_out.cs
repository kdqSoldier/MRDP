using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class Listhz_out
    {
        public string num;
        public List<string> point_;
        public List<string> dat_2c;
        public List<string> dat_Average;
        public List<string> dat_3;
        public Listhz_out(string num, List<string> point_, List<string> dat_2c, List<string> dat_Average)
        {
            this.num = num;
            this.point_ = point_;
            this.dat_2c = dat_2c;
            this.dat_Average = dat_Average;
        }
    }
}
