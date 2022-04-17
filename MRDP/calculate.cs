using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDP
{
    class calculate
    {
        //计算入口
        public void Calculate_()
        {
            int khz = parameter.list_hz.Count;
            int kv = parameter.list_v.Count;
            int kdist = parameter.list_dist.Count;
            if (khz!=kv && kv!=kdist)
            {
                error.numdiff();
            }
            else
            {
                for (int i = 0; i < kv; i++)
                {
                    string point=parameter.dict_v.ElementAt(i).Key;
                    cal_2c(point);
                    cal_v2(point);
                    cal_dist4(point);
                }
            }
        }
        
        //计算2C 
        public void cal_2c(string point)
        {
            int guancedian = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            List<string> dat2001;
            List<double> data01;
            List<string> dat2002;
            list_hzout dat4001;
            Listhz_out dat3001;
            List<Listhz_out> dat5001=new List<Listhz_out>();
            int k01 = parameter.dict_hz[point];            
            for (int i = 0; i < cehuishu; i++)
            {
               
                dat2001 = new List<string>();
                data01 = new List<double>();
                for (int j = 0; j < guancedian; j++)
                {
                    double datl = _angle(parameter.list_hz[k01].data_hz[i].dat_l[j]);
                    double datr = _angle(parameter.list_hz[k01].data_hz[i].dat_r[j]);
                    double dat1001 =0;
                    double dat1002 = 0; 
                    if (datl<datr)
                    {
                        dat1001 = datr - 180 - datl;
                        dat1002 = (datr - 180+datl ) / 2;
                    }
                    else if (datl >= datr)
                    {
                        dat1001 = datr + 180 - datl;
                        dat1002 = (datr + 180+datl ) / 2;
                    }
                    data01.Add(dat1002);
                    //data01.Add(Math.Round(dat1001*3600,2).ToString());
                    dat2001.Add((_radian(dat1001)*10000).ToString());
                }
                dat2002 = new List<string>();
                double t = data01[0];
                for (int k = 0; k < data01.Count; k++)
                {
                    if ( data01[k] >= t)
                    {
                        data01[k] = data01[k] - t;
                    }
                    else if (data01[k] < t)
                    {
                        data01[k] = data01[k]+360 - t;
                    }
                    
                    dat2002.Add(_radian(data01[k]).ToString());                   
                }
                dat3001 = new Listhz_out(i.ToString(), parameter.list_hz[k01].data_hz[i].point_, dat2001, dat2002);
                dat5001.Add(dat3001);
                //parameter.listhz_out.Add(dat3001);
                //parameter.list_hz[k01].data_hz[i].dat_1.AddRange(dat3001);                
                //List<string> dat20015 = parameter.list_hz[k01].data_hz[0].dat_l;
            }
            dat4001 = new list_hzout(point,dat5001);            
            parameter.list_hzout.Add(dat4001);
        }
        
        //计算归零值
        public void cal_Average(string point)
        {
            int guancedian = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            int k01 = parameter.dict_hz[point];
            for (int i = 0; i < cehuishu; i++)
            {
                List<string> dat2001 = new List<string>();
                List<double> data01 = new List<double>();
                for (int j = 0; j < guancedian; j++)
                {

                    double datl = _angle(parameter.list_hz[k01].data_hz[i].dat_l[j]);
                    double datr = _angle(parameter.list_hz[k01].data_hz[i].dat_r[j]);
                    double dat1001 = 0.0;
                    if (datl<=datr)
                    {
                        dat1001 = (datl + datr - 180) / 2;
                    }
                    else if (datl>datr)
                    {
                        dat1001 = (datl + datr + 180) / 2;
                    }
                    data01.Add(dat1001);
                    //data01.Add(Math.Round(dat1001*3600,2).ToString());
                    //parameter.list_hz[k01].data_hz[i].dat_2.Add(Math.Round(dat1001).ToString());
                }
                double t = data01[0];
                for (int k = 0; k < data01.Count; k++)
                {
                    data01[k] = data01[k] - t;
                    dat2001.Add(_radian(data01[k]).ToString());
                }
                parameter.list_hz[k01].data_hz[i].dat_2.AddRange(dat2001);
            }
        }
        
        //计算I角  天顶角
        public void cal_v2(string point)
        {
            int guancedian = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            int k01 = parameter.dict_v[point];
            List<Listv_out> dat5001 = new List<Listv_out>();
            for (int i = 0; i < cehuishu; i++)
            {
                List<string> dat2001 = new List<string>();
                List<string> dat2002 = new List<string>();
                List<string> dat2003 = new List<string>();
                List<double> data01 = new List<double>();
                for (int j = 0; j < guancedian; j++)
                {
                    double datl = _angle(parameter.list_v[k01].data_v[i].dat_l[j]);
                    double datr = _angle(parameter.list_v[k01].data_v[i].dat_r[j]);
                    double dat1001 = 0.0;
                    dat1001 = (datl + datr - 360) / 2;
                    double dat1002 = 0.0;
                    dat1002 =datl - dat1001;
                    //data01.Add(dat1001);
                    //data01.Add(Math.Round(dat1001*3600,2).ToString());
                    dat2001.Add((_radian(dat1001) * 10000).ToString()); 
                    dat2002.Add(_radian(dat1002).ToString());
                    dat2003.Add((90 - (dat1002)).ToString());                   
                }
                Listv_out dat3001 = new Listv_out(i.ToString(), parameter.list_v[k01].data_v[i].point_, dat2001, dat2002, dat2003);
                dat5001.Add(dat3001);
                //parameter.listv_out.Add(dat3001);
                ////i
                //parameter.list_v[k01].data_v[i].dat_1.AddRange(dat2001);
                ////天顶角
                //parameter.list_v[k01].data_v[i].dat_2.AddRange(dat2002);
                //parameter.list_v[k01].data_v[i].dat_3.AddRange(dat2003);
            }
            list_vout dat4001 = new list_vout(point, dat5001);
            parameter.list_vout.Add(dat4001);
        }
    
        //计算距离较差 斜距 平距
        public void cal_dist4(string point)
        {
            int k02 = parameter.dict_v[point];
            int guancedian = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            int k01 = parameter.dict_v[point];
            List<Listdist_out> dat5001 = new List<Listdist_out>();
            for (int i = 0; i < cehuishu; i++)
            {
                List<string> dat2001 = new List<string>();
                List<string> dat2002 = new List<string>();
                List<string> dat2003 = new List<string>();
                List<string> dat2004 = new List<string>();

                List<double> data01 = new List<double>();
                for (int j = 0; j < guancedian; j++)
                {
                    double datl = _angle(parameter.list_dist[k01].data_dist[i].dat_l[j]);
                    double datr = _angle(parameter.list_dist[k01].data_dist[i].dat_r[j]);
                    double dat1001 = 0.0;
                    dat1001 = datl - datr;
                    double dat1002 = 0.0;
                    dat1002 = (datl + datr )/ 2;
                    //data01.Add(dat1001);
                    //data01.Add(Math.Round(dat1001*3600,2).ToString());
                    double dat1004 =double.Parse(parameter.list_vout[k02].list_dat[i].dat_3[j]);
                    double dat1005 = Math.Cos(dat1004 / 180 * Math.PI) * (dat1002);
                    double dat1006 = Math.Sin(dat1004 / 180 * Math.PI) * (dat1002);

                    dat2001.Add((dat1001).ToString());
                    dat2002.Add((dat1002).ToString());
                    dat2003.Add((dat1005).ToString());
                    dat2004.Add((dat1006).ToString());  

                }
                Listdist_out dat3001 = new Listdist_out(i.ToString(), parameter.list_dist[k01].data_dist[i].point_, dat2001, dat2002, dat2003, dat2004);
                dat5001.Add(dat3001);
                //parameter.listdist_out.Add(dat3001);
                ////距离较差
                //parameter.list_dist[k01].data_dist[i].dat_1.AddRange(dat2001);
                ////斜距
                //parameter.list_dist[k01].data_dist[i].dat_2.AddRange(dat2002);
                ////平距
                //parameter.list_dist[k01].data_dist[i].dat_3.AddRange(dat2003);
                ////高差
                //parameter.list_dist[k01].data_dist[i].dat_4.AddRange(dat2004);
            }
            list_distout dat4001 = new list_distout(point, dat5001);
            parameter.list_distout.Add(dat4001);
        }

        //***转角度radian angle
        public static double _angle(object app)
        {
            double[] angle = new double[3];
            string app0 = (app).ToString();
            angle[0] = double.Parse(app0.Substring(0, app0.IndexOf(".")));
            angle[1] = double.Parse(app0.Substring(app0.IndexOf(".") + 1, app0.IndexOf(",") + 3));
            angle[2] = double.Parse(app0.Substring(app0.IndexOf(".") + 3)) / Math.Pow(10, app0.Substring(app0.IndexOf(".") + 3).Length - 2);

            double Angle = angle[0] + angle[1] / 60 + angle[2] / 3600;
            return Angle;
        }

        //角度转**
        public static double _radian(object app)
        {

            double app0 = double.Parse((app).ToString());
            double s = app0 / (1 / app0);
            app0 = Math.Abs(app0);
            double du = Math.Floor(app0);
            double fen = Math.Floor(app0 * 60 - du * 60);
            du = du + Math.Floor(fen / 60);
            fen = fen - Math.Floor(fen / 60) * 60;
            double miao = app0 * 3600 - du * 3600 - fen * 60;
            fen = fen + Math.Floor(miao / 60);
            miao = miao - Math.Floor(miao / 60) * 60;
            du = du + Math.Floor(fen / 60);
            fen = fen - Math.Floor(fen / 60) * 60;

            double radian = du + fen / 100 + miao / 10000;
            return radian;
        }
        //弧度换角度
        public static double pi_angle(object app)
        {
            double app0 = double.Parse((app).ToString());
            double angle = (app0 / Math.PI) * 180;
            return angle;
        }
        //角度转弧度
        public static double angle_pi(object app)
        {
            double app0 = double.Parse((app).ToString());
            double pi = (app0 / 180) * Math.PI;
            return pi;
        }
    }
}
