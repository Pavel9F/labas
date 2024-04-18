using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    class Fraction
    {
        private int _num;
        private int _denum;

        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }

        public int Denum
        {
            get { return _denum; }
            set { _denum = value; }
        }
        public Fraction(int num, int denum)
        { 
            _num = num;
            _denum = denum;
        }

        public override string ToString()
        {
            int num = _num;
            int denum = _denum;
            int[] simple = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 57, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139 };
            if (num % denum == 0) return $"{num / denum} / 1";
            foreach (int i in simple)
            {
                while (num % i == 0 && denum % i == 0)
                {
                    num /= i;
                    denum /= i;
                }
            }
            return $"{num} / {denum}";
        }

        public Fraction Add(Fraction second)
        {
            if (_denum == second.Denum) return new Fraction(_num + second._num, _denum);
            else
            {
                int num = _num * second.Denum + second.Num * _denum;
                int denum = _denum * second.Denum;
                return new Fraction(num, denum);
            }
        }
        public Fraction Sub(Fraction second)
        {
            if (_denum == second.Denum) return new Fraction(_num - second._num, _denum);
            else
            {
                int num = _num * second.Denum - second.Num * _denum;
                int denum = _denum * second.Denum;
                return new Fraction(num, denum);
            }
        }
        public Fraction Mul(Fraction second)
        {
            int num = _num * second.Num;
            int denum = _denum * second.Denum;
            return new Fraction(num, denum);
        }
        public Fraction Div(Fraction second)
        {
            int num = second.Denum;
            int denum = second.Num;
            Fraction a = new Fraction(num, denum);
            return Mul(a);
        }
        public bool Is_bigger(Fraction second)
        {
            int num = second.Num;
            int denum = second.Denum;

            if (num / denum < _num / _denum) return true;
            return false;
        }

    }
    internal class Program
    {
        static void Mafdin(string[] args)
        {
            string[] temp;
            Fraction a;
            Fraction b;

        a:
            try
            {
                Console.WriteLine("Введите первую дробь в формате [числитель]/[знаменатель]");
                temp = Console.ReadLine().Split('/').ToArray();
                a = new Fraction(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]));
            }
            catch (Exception)
            {
                goto a;
            }

        b:
            try
            {
                Console.WriteLine("Введите Вторую дробь в формате [числитель]/[знаменатель]");
                temp = Console.ReadLine().Split('/').ToArray();
                b = new Fraction(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]));
            }
            catch (Exception)
            {
                goto b;
            }

            Console.WriteLine($"Сумма дробей: {a.Add(b)}");
            Console.WriteLine($"Разность дробей: {a.Sub(b)}");
            Console.WriteLine($"Произведение дробей: {a.Mul(b)}");
            Console.WriteLine($"Частное дробей: {a.Div(b)}");
            Console.WriteLine($"Результат сравнения дробей: {a.Is_bigger(b)}");

            Console.ReadKey();
        }
    }
}
