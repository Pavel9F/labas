using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _111
{
    struct Order
    {
        public int sum;
        public int acc1;
        public int acc2;
    }
    public partial class Form1 : Form
    {
        Random random = new Random();
        Order[] orders = new Order[10];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                orders[i] = new Order(){
                    acc1 = random.Next(10000000, 99999999),
                    acc2 = random.Next(10000000, 99999999),
                    sum = random.Next(1000, 90000)
                };
            }
            using (StreamWriter sw = new StreamWriter("../../file.txt"))
            {
                foreach (Order order in orders)
                {
                    sw.Write(order.acc1 + "                  ");
                    sw.Write(order.acc2 + "               ");
                    sw.WriteLine(order.sum);
                }
            }
            using (StreamReader sr = new StreamReader("../../file.txt"))
                textBox1.Text = sr.ReadToEnd();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("../../file.txt"))
                textBox1.Text = sr.ReadToEnd();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("../../file.txt"))
            {
                sw.Write(textBox1.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("../../file.txt"))
            {
                sw.Write(textBox1.Text);
            }
            using (StreamReader sr = new StreamReader("../../file.txt"))
            {
                string str = sr.ReadToEnd();
                string[] temp = str.Split('\n');
                for (int i = 0; i < 10; i++)
                {
                    temp[i] = temp[i].Replace("                  ", " ");
                    temp[i] = temp[i].Replace("               ", " ");
                    orders[i].acc1 = Convert.ToInt32(temp[i].Split(' ')[0]);
                    orders[i].acc2 = Convert.ToInt32(temp[i].Split(' ')[1]);
                    orders[i].sum = Convert.ToInt32(temp[i].Split(' ')[2]);
                }
            }

            //sort
            for (int i = 0; i < orders.Length - 1; i++)
            {
                for (int j = 0; j < orders.Length - 1 - i; j++)
                {
                    if (orders[j].acc1 > orders[j + 1].acc1)
                    {
                        Order temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter("../../file.txt"))
            {
                foreach (Order order in orders)
                {
                    sw.Write(order.acc1 + "                  ");
                    sw.Write(order.acc2 + "               ");
                    sw.WriteLine(order.sum + " Р");
                }
            }
            using (StreamReader sr = new StreamReader("../../file.txt"))
                textBox1.Text = sr.ReadToEnd();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("../../file.txt"))
            {
                Order[] order = new Order[10];
                string str = sr.ReadToEnd();
                string[] temp = str.Split('\n');
                for (int i = 0; i < 10; i++)
                {
                    temp[i] = temp[i].Replace("                  ", " ");
                    temp[i] = temp[i].Replace("               ", " ");
                    order[i].acc1 = Convert.ToInt32(temp[i].Split(' ')[0]);
                    order[i].acc2 = Convert.ToInt32(temp[i].Split(' ')[1]);
                    order[i].sum = Convert.ToInt32(temp[i].Split(' ')[2]);
                }

                try
                {
                    int aim = Convert.ToInt32(textBox2.Text);
                    int result = 0;
                    foreach (Order order1 in order)
                    {
                        if (order1.acc1 == aim)
                        {
                            result = order1.sum;
                            break;
                        }
                    }
                    if (result == 0)
                    {
                        MessageBox.Show("Совпадений не найдено");
                    }
                    else
                    {
                        MessageBox.Show($"Сумма {result}");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверный формат");
                }
                
            }
        }
    }
}
