using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MRDP
{
    class showdata
    {
        public static void showpath(string text)
        {
            Form1.form1.textBox1.Text = text;
            Form1.form1.textBox2.Text = text;

        }
        public static void showpoint(Dictionary<string, int> text)
        {
            Form1.form1.textBox3.Clear();
            for (int i = 0; i < text.Count; i++)
            {
                Form1.form1.textBox3.AppendText("测站点" + i + " * " + text.ElementAt(i).Key + "\r\n");
            }
        }



    }
}
