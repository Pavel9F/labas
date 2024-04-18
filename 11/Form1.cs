using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(trackBar1.Value);
            double sum = 0;

            if (radioButton1.Checked)
            {
                for (int i = 1; i < Math.Pow(-1, n)*Math.Pow(2*n + 1, 2); i+=2)
                {
                    sum += (double)i;
                }
                MessageBox.Show("Полученная сумма: " + sum);
            }
            else if (radioButton2.Checked)
            {
                sum = Math.Pow(-1, n) * 2 * Math.Pow(n+1, 2) - (1 + Math.Pow(-1, 2)) / 2;
                MessageBox.Show("Полученная сумма: " + sum);
            }
            else
            {
                MessageBox.Show("Выберите способ расчета");
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }
    }
}
