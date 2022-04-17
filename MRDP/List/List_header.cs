using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class List_header
    {
        public string point;
        public string surveysets;
        public string period_Num;
        public string equipmentHi;
        public string data_year;
        public string data_h;
        public string other;
        public List_header(string Point, string surveysets, string period_Num, string equipmentHi, string data_year, string data_h, string other)
        {
            this.point = Point;
            this.surveysets = surveysets;
            this.period_Num = period_Num;
            this.equipmentHi = equipmentHi;
            this.data_year = data_year;
            this.data_h = data_h;
            this.other = other;
        }

    }
}
