using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class constant
    {
        public const string type_HZ="HZ";
        public const string type_V="V";
        public const string type_Dist="dist";
        public const string filepath_="null";
        public const string title_V="选择竖直角测量文件";
        public const string title_HZ="选择水平角测量文件";
        public const string title_Dist="选择距离测量文件";
        public const string pathname = @"\测量数据预处理.xlsx";

        public static readonly string[] dat=new string[]{"水平盘读数","2C","归零方向值","竖盘读数","i","天顶角","斜距","较差","平距","觇标高"};
        public static readonly string[] dat_ = new string[] {"(° ′ ″)","(  ″ )","(° ′ ″)","(° ′ ″)","(  ″ )","(° ′ ″)","( m )","( mm )","( m )","( m )"};
        public static readonly string[] datshow = new string[] { "Ⅰ", "Ⅱ" };
        public static readonly string[] com =new string[]{"SUO","TPT&TZT&TXT"};
        public static readonly int[] com_int = new int[] { 0, 1 };

        public static readonly string[] type_file = new string[] { "*.txt", "*.tpt", "*.tzt" };
        public static readonly string[] type_data = new string[] { type_Dist, type_HZ, type_V };

        public const string start_dist = "Dist Start";
        public const string end_dist = "Dist End";
        public const string start_hz = "Hz Start";
        public const string end_hz = "Hz End";
        public const string start_v = "V Start";
        public const string end_v = "V End";
    }
}
