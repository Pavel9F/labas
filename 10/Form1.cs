using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10
{
    public partial class Per : Form
    {
        double ax, bx, cx, ay, by, cy;

        private void button2_Click(object sender, EventArgs e)
        {
            int n;
            double sum = 0;

            try
            {
                n = Convert.ToInt32(textBox7.Text);
                if (radioButton1.Checked)
                {
                    for (int i = 0; i < n; i++)
                    {
                        sum += Math.Pow(i, 4);
                    }
                    MessageBox.Show($"Рассчитана последовательность: {sum}");
                }
                else if (radioButton2.Checked)
                {
                    sum = n * (n + 1) * (2 * n + 1) * (3 * Math.Pow(n, 2) + 3 * n - 1) / 30;
                    MessageBox.Show($"Рассчитана последовательность: {sum}");
                }
                else
                {
                    MessageBox.Show($"Выберите способ рассчета");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные");
            }

            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public Per()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ax = Convert.ToDouble(textBox1.Text);
                bx = Convert.ToDouble(textBox2.Text);
                cx = Convert.ToDouble(textBox3.Text);
                ay = Convert.ToDouble(textBox6.Text);
                by = Convert.ToDouble(textBox5.Text);
                cy = Convert.ToDouble(textBox4.Text);

                double a = Math.Pow(Math.Pow(bx - ax, 2) + Math.Pow(by - ay, 2), 0.5);
                double b = Math.Pow(Math.Pow(cx - ax, 2) + Math.Pow(cy - ay, 2), 0.5);
                double c = Math.Pow(Math.Pow(cx - bx, 2) + Math.Pow(cy - by, 2), 0.5);

                double per = a+b+c;
                double sq = per/2 * (per/2 - a) * (per/2 - b) * (per/2 - c);

                MessageBox.Show($"Периметр треугольника: {per}\nПлощадь: {sq}");
            }
            catch (Exception)
            {
                MessageBox.Show("Введенные данные не верны.\n");
            }
        }
    }
}
