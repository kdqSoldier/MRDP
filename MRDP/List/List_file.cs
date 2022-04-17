using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class List_file
    {
        public string point;
        public string path;
        public Dictionary<string, string> file;
        public List_file(string point, string path, Dictionary<string, string> file)
        {
            this.point = point;
            this.path = path;
            this.file = file;
        }
    }
}
