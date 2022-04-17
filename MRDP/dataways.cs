using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MRDP
{
    class dataways
    {
        string point;
        //数据分割模块入口
        public void load()
        {
            for (int i = 0; i < parameter.list_file.Count; i++)
            {
                loadheader(parameter.list_file[i].file[constant.type_Dist]);
                loaddist(parameter.list_file[i].file[constant.type_Dist]);
                loadhz(parameter.list_file[i].file[constant.type_HZ]);
                loadv(parameter.list_file[i].file[constant.type_V]);
            }
        }
        //读取dist拓展
        public void loaddist2(List<string> point_, List<string> dist, List<string> high, int cehuishu, int guancedian)
        {
            List<List_da> dat2 = new List<List_da>();
            List<string> point_0;                                                 
            List<string> dist0;
            List<string> high0;
            int kp = point_.Count / cehuishu;
            int kd = dist.Count / cehuishu;
            int kh = high.Count / cehuishu;
            //List<string> s1 = new List<string>();
            //List<string> s2 = new List<string>();
            //List<string> s3 = new List<string>();
            //List<string> s4 = new List<string>();
            for (int i = 0; i < guancedian; i++)
            {
                point_0 = new List<string>();
                dist0 = new List<string>();
                high0 = new List<string>();
                for (int j = 0; j < cehuishu; j++)
                {
                    point_0.Add(point_[i + (j * kp)]);
                    dist0.Add(dist[i + (j * kp)]);
                    high0.Add(dist[i + (j * kp)]);
                }
                List_da da = new List_da(i.ToString(), point_0, dist0, high0);
                dat2.Add(da);
            }
            List_Dist data = new List_Dist(point, dat2);
            parameter.list_dist.Add(data);
            parameter.dict_dist.Add(point, parameter.list_dist.Count - 1);
        }
        //读取dist
        public void loaddist(string path)
        {
            //List<string> s1 = new List<string>();
            //List<string> s2 = new List<string>();
            //List<string> s3 = new List<string>();
            //List<string> s4 = new List<string>();
            List<List_da> dat2 = new List<List_da>();
            int j = 1;
            int k03 = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            List<string> point_ = new List<string>();
            List<string> dist = new List<string>();
            List<string> high = new List<string>();
            int guancedian = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            string[,] dat1001 = new string[cehuishu, cehuishu];
            Regex start = new Regex(constant.start_dist);
            Regex end = new Regex(constant.end_dist);
            bool set = false;
            List<string> list_dist = filenways.GETtext(path);
            for (int i = 0; i < list_dist.Count; i++)
            {
                string dat0 = list_dist[i];
                if (end.IsMatch(dat0))
                {
                    set = false;
                }
                if (set)
                {
                    for (int k = 1; k <= guancedian; k++)
                    {
                        string[] dat1 = list_dist[i].Split(',');
                        point_.Add(dat1[1]);
                        dist.Add(dat1[2]);
                        high.Add(dat1[3]);
                        i++;
                    }
                    i--;
                }
                if (start.IsMatch(dat0))
                {
                    set = true;
                }
            }
            loaddist2(point_, dist, high, cehuishu, guancedian);

        }
        //读取头文件
        public void loadheader(string path)
        {

            List<string> herde = filenways.GETtext(path);
            string[] dat0 = herde[0].Split(',');
            point = dat0[0];
            Regex reg = new Regex("[0-9]{4}-[0-9]+-[0-9]+");
            Regex reg1 = new Regex("[0-9]+:[0-9]+:[0-9]+");
            Match date = reg.Match(herde[1].ToString());
            Match time = reg1.Match(herde[1].ToString());
            string other = herde[1].ToString().Substring(herde[1].ToString().LastIndexOf(",") + 1);
            List_header dat = new List_header(dat0[0], dat0[1], dat0[2], dat0[3], date.Value, time.Value, other);
            parameter.list_header.Add(dat);
            parameter.dict_header.Add(dat0[0], parameter.list_header.Count - 1);
            herde.Clear();
        }
        //读取hz文件
        public void loadhz(string path)
        {
            //List<string> s1 = new List<string>();
            //List<string> s2 = new List<string>();
            //List<string> s3 = new List<string>();
            //List<string> s4 = new List<string>();
            List<List_da> dat2 = new List<List_da>();
            List<string> list_hz = filenways.GETtext(path);
            List<string> point_;
            List<string> hz_l;
            List<string> hz_r;
            int guancedian = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            Regex start = new Regex(constant.start_hz);
            Regex end = new Regex(constant.end_hz);
            bool set = false;
            for (int i = 0; i < list_hz.Count; i++)
            {
                string dat0 = list_hz[i];
                if (end.IsMatch(dat0))
                {
                    set = false;
                }
                if (set)
                {
                    for (int j = 1; j <= cehuishu; j++)
                    {
                        point_ = new List<string>();
                        hz_l = new List<string>();
                        hz_r = new List<string>();
                        i++;
                        for (int k = 1; k <= guancedian; k++)
                        {
                            string dat00 = list_hz[i];
                            string[] dat1 = dat00.Split(',');
                            point_.Add(dat1[0]);
                            hz_l.Add(dat1[1]);
                            hz_r.Add(dat1[2]);
                            i++;
                        }
                        List_da da = new List_da(j.ToString(), point_, hz_l, hz_r);
                        dat2.Add(da);
                    }
                }
                if (start.IsMatch(dat0))
                {
                    set = true;
                }
            }
            List_Hz data = new List_Hz(point, dat2);
            parameter.list_hz.Add(data);
            parameter.dict_hz.Add(point, parameter.list_hz.Count - 1);

        }
        //读取V文件
        public void loadv(string path)
        {
            //List<string> s1 = new List<string>();
            //List<string> s2 = new List<string>();
            //List<string> s3 = new List<string>();
            //List<string> s4 = new List<string>();
            List<List_da> dat2 = new List<List_da>();
            List<string> list_v = filenways.GETtext(path);
            List<string> point_ = new List<string>();
            List<string> v_l = new List<string>();
            List<string> v_r = new List<string>();
            List<string> high = new List<string>();
            int guancedian = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            Regex start = new Regex(constant.start_v);
            Regex end = new Regex(constant.end_v);
            bool set = false;
            for (int i = 0; i < list_v.Count; i++)
            {
                string dat0 = list_v[i];
                if (end.IsMatch(dat0))
                {
                    set = false;
                }
                if (set)
                {
                    for (int j = 1; j <= cehuishu; j++)
                    {
                        point_ = new List<string>();
                        v_l = new List<string>();
                        v_r = new List<string>();
                        high = new List<string>();
                        i++;
                        for (int k = 1; k <= guancedian; k++)
                        {
                            string dat00 = list_v[i];
                            string[] dat1 = dat00.Split(',');
                            point_.Add(dat1[0]);
                            v_l.Add(dat1[1]);
                            v_r.Add(dat1[2]);
                            high.Add(dat1[3]);
                            i++;
                        }
                        List_da da = new List_da(j.ToString(), point_, v_l, v_r);
                        dat2.Add(da);
                    }
                }
                if (start.IsMatch(dat0))
                {
                    set = true;
                }

            }
            List_V data = new List_V(point, high, dat2);
            parameter.list_v.Add(data);
            parameter.dict_v.Add(point, parameter.list_v.Count - 1);
        }

    }
}
