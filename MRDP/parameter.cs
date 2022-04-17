using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class parameter
    {
        public static List<List_header> list_header = new List<List_header>();
        public static Dictionary<string, int> dict_header = new Dictionary<string, int>();

        public static List<List_Dist> list_dist = new List<List_Dist>();
        public static Dictionary<string, int> dict_dist = new Dictionary<string, int>();

        public static List<List_Hz> list_hz = new List<List_Hz>();
        public static Dictionary<string, int> dict_hz = new Dictionary<string, int>();

        public static List<List_V> list_v = new List<List_V>();
        public static Dictionary<string, int> dict_v = new Dictionary<string, int>();

        public static List<string> TXT = new List<string>();
        public static List<string> folder = new List<string>();

        public static List<List_file> list_file = new List<List_file>();
        public static Dictionary<string, int> dict_file = new Dictionary<string, int>();

        public static Dictionary<string, string> type_data = new Dictionary<string, string>();

        public static List<Listhz_out> listhz_out = new List<Listhz_out>();
        public static Dictionary<string, int> dicthz_out = new Dictionary<string, int>();

        public static List<Listv_out> listv_out = new List<Listv_out>();
        public static Dictionary<string, int> dictv_out = new Dictionary<string, int>();

        public static List<Listdist_out> listdist_out= new List<Listdist_out>();
        public static Dictionary<string, int> dictdist_out = new Dictionary<string, int>();

        public static List<list_hzout> list_hzout = new List<list_hzout>();

        public static List<list_vout> list_vout = new List<list_vout>();

        public static List<list_distout> list_distout = new List<list_distout>();

        public static Dictionary<string,int> dictin_TXT=new Dictionary<string, int>();
        public static Dictionary<string, int> dictin_TZT = new Dictionary<string, int>();
        public static Dictionary<string, int> dictin_TPT = new Dictionary<string, int>();
        public static readonly List<List_show> combox = new List<List_show>();
        public static List<List_header> listout_file=new List<List_header>();
        public static string path;
    }
}
