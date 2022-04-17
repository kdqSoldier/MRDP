using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MRDP
{
    class filenways
    {        
        //弹出打开文件
        public  void open_file(out string filepath,bool set=true)
        {
            parameter.list_file.Clear();
            parameter.dict_file.Clear();
            filepath = string.Empty;            
            FolderBrowserDialog openfile = new FolderBrowserDialog();
            openfile.Description = "选择文件夹";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                filepath = openfile.SelectedPath;
                if (set)
                {
                    main_file(filepath);
                }               
            }
        }

        //获取文件
        public  void main_file(string path)
        {
            List<string> folder = new List<string>();
            getfloder(path,out folder);
            getfile(folder);
        }

        //截取字符串
        public  void getname(string path,out string name,out string point)
        {
            name = string.Empty;
            point = string.Empty;
            name = path.Substring(path.LastIndexOf("\\") + 1);
        }

        //获取文件夹 folder
        public void getfloder(string path,out List<string> folder)
        {
            folder = new List<string>();
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();
            if (dics.Count()==0)
            {
                folder.Add(path);
            }
            else
            {
                foreach (DirectoryInfo Folder in dics)
                {
                    folder.Add(path + "\\" + Folder.ToString());                    
                }
            }
        }

        //获取文件菜单
        public void getfile(List<string> folder)
        {
            string[] type = constant.type_file;
            foreach (string path in folder)
            {
                Dictionary<string,string> data=new Dictionary<string,string>();
                string point="null";
                string[] soacf = Directory.GetFiles(path, "*.soacf");
                foreach (string name_ in soacf)
                {
                    StreamReader r = new StreamReader(name_);
                    string dat0 = r.ReadLine();
                    point = dat0.Substring(dat0.IndexOf(":") + 1);
                    r.Close();
                }
                foreach (string typ in  type)
                {
                    string[] dat0 = Directory.GetFiles(path, typ);
                    foreach (string dat1 in dat0)
                    {
                        if (data.ContainsKey(parameter.type_data[typ]))
                        {
                            data[parameter.type_data[typ]] = dat1;
                        }
                        data.Add(parameter.type_data[typ], dat1);
                    }                                       
                }                
                //data = Directory.GetFiles(path, "*.txt");
                // data = Directory.GetFiles(path, "*.txt");
                List_file dat =new List_file(point,path,data);
                parameter.list_file.Add(dat);
                parameter.dict_file.Add(point, parameter.list_file.Count - 1);
            }

        }

        //读取文件
        public static List<string> GETtext(string path)
        {
            List<string> text=new List<string>();
            string[] tex = File.ReadAllLines(path);
            text.AddRange(tex);
            return text;
        }
    }
}
