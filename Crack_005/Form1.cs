using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace Crack_005
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        long[] c = new long[200];
        int n=0,p=0;
        private void button1_Click(object sender, EventArgs e)
        {
//            button2.Enabled = true;

            textBox2.ReadOnly = false;
            long b;
            long temp1 = 0, temp2 = 0,k=0;
            n = 0;
            string a,str;
            a = textBox1.Text;
            str = textBox3.Text;
            char[] a1 = a.ToCharArray();
            char[] a2 = str.ToCharArray();
            //测试
//            for (int i = 0; i < a.Length; i++)
//                textBox3.Text += Convert.ToString(a1[i]);
            for(int i=0;i<a.Length;i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    temp1 += (Convert.ToInt32(a1[j])) * (Convert.ToInt32(a1[i]));
                }
            }
            for(int m=0;m<str.Length-1;m++)
            {
                temp2 += (Convert.ToInt32(str[m+1])%17+1)*(Convert.ToInt32(str[m]));
            }
            temp2 += 891;
            temp2 = temp2 % 29000;
            //            textBox3.Text += "  " + temp2;

            //            textBox3.Text += "  " + temp1;
//            textBox3.Text = "" + temp1 * temp2;
            if ((temp1 * temp2 < 2147483647)&&(a.Length>5))
            {
                temp1 = (temp1 * temp2) % 666666;
                for (k = 0; k < 100000000; k++)
                {
                    b = k / 89 + k % 80 + 1;
                    if (temp1 == b)
                    {
                        c[n] = k;
                        n++;
                    }
                }
                textBox2.Text = Convert.ToString(c[0]);
                button2.Enabled = true;
            }
            else
                textBox2.Text = "用户名不符合要求，请重新输入";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(c[p]);
            p++;
            if (p == n)
                p = 0;
        }
    }
}
