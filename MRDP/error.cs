using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MRDP
{
    class error
    {
        public static void datahave()
        {
            MessageBox.Show("警告", "以存在相同点号的数据",MessageBoxButtons.OK);
        }
        public static void numdiff()
        {            
            MessageBox.Show("错误", "致命错误，请检查数据", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
