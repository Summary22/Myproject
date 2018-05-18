using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p2w
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int c1, c2, c3, c4, c5, c6;
            string[] result=new string[22];
            for (int i = 0; i < 20; i++)
                result[i] = "0";
                
            Random rd = new Random() ;
            string a = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] a1 = a.ToCharArray();
            c1 = rd.Next(2,9);
            c2 = 11 - c1;

            result[0] = Convert.ToString(c1);
            result[1] = Convert.ToString(c2);//第一个条件相加等于11
            
            c3 = rd.Next(4,9);
            c4 = 13 - c3;
            result[18] = Convert.ToString(c3);
            result[19] = Convert.ToString(c4);//第二个条件相加等于13

            c5 = rd.Next(1, 8);
            c6 = 9 - c5;
            result[5] = Convert.ToString(c5);
            result[13] = Convert.ToString(c6);//第二个条件相加等于13

            result[12] = "V";
            result[14] = "3";
            result[15] = "2";

            for(int i=0;i<20;i++)
            {
                if(result[i]!="0")
                    textBox1.Text += result[i];
                else 
                    textBox1.Text += a1[rd.Next(0, 35)];
            }
        }
    }
}
