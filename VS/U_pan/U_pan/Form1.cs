using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace U_pan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            int temp;
            //            string input = "E3A0A812D00294";

            string input=textBox1.Text;
            char[] a = input.ToCharArray();
            for (int ebx = 1; ebx <= input.Length; ebx++)
            {
                temp = (ebx * 2 + 1) + Convert.ToInt32(a[ebx - 1]) + 1;
                if (((temp < 58) && (temp > 47)) || ((temp < 91) && (temp > 64)))
                {
                    textBox2.Text += Convert.ToChar(temp);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
                button1.Enabled = true;
        }
    }
}
