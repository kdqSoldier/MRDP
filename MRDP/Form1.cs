using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MRDP
{
    public partial class Form1 : Form
    {
        public static Form1 form1;
        public Form1()
        {
            form1 = this;
            InitializeComponent();
        }
        filenways fileway = new filenways();
        dataways dataway = new dataways();
        calculate calculat = new calculate();
        excelways excelway=new excelways();
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string path;
                fileway.open_file(out path);
                parameter.path = path;
                showdata.showpath(path);
                showdata.showpoint(parameter.dict_dist);
            }
            catch (Exception)
            {

                MessageBox.Show("未知错误", "警告");
            }
                     
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                textBox4.AppendText("***  计算中，请等待.....................");
                textBox4.AppendText("");
                dataway.load();
                showdata.showpoint(parameter.dict_hz);
                calculat.Calculate_();
                excelway.saveexcel(textBox2.Text);
                textBox4.AppendText("***  计算完成。\n");
            }
            catch (Exception)
            {

                MessageBox.Show("未知错误", "警告");
            }
              
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <constant.com.Count(); i++)
			{
                List_show dat = new List_show(constant.com_int[i],constant.com[i]);
                parameter.combox.Add(dat);                
			}
            for (int i = 0; i < constant.type_data.Count(); i++)
            {
                parameter.type_data.Add(constant.type_file[i], constant.type_data[i]);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string path;
            fileway.open_file(out path,false);
            parameter.path = path;
        }


    }
}
