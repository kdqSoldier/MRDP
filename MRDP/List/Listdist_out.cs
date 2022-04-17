using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class Listdist_out
    {

        public string num;
        public List<string> point_;
        public List<string> dat_poor;
        public List<string> dat_draw;
        public List<string> dat_slant;
        public List<string> dat_Elevation;
        public Listdist_out(string num, List<string> point_, List<string> dat_poor, List<string> dat_draw,List<string> dat_slant,List<string> dat_Elevation)
        {
            this.num = num;
            this.point_ = point_;
            this.dat_poor = dat_poor;
            this.dat_draw = dat_draw;
            this.dat_slant = dat_slant;
            this.dat_Elevation = dat_Elevation;

        }

    }
}
