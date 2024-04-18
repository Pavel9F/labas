using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    abstract class Figure
    {
        public abstract double Square();

        ~Figure()
        {

        }
    }

    class Rectangle : Figure
    {
        protected int a, b;
        public Rectangle(int a, int b) 
        { 
            this.a = a; this.b = b;
        }

        public override double Square()
        {
            return a * b;
        }

    }

    class Triangle : Figure
    {
        protected double _a, _b, _c;
        protected double _pp;

        public Triangle(double a, double b, double c)
        {
            _a = a; _b = b; _c = c;
            _pp = (a + b + c) / 2;
        }

        public override double Square()
        {
            return _pp * (_pp - _a) * (_pp - _b) * (_pp - _c);
        }
    }

    class SquareR : Figure
    {
        protected int _a, _b;
        public SquareR(int a)
        {
            _a = a;
        }

        public override double Square()
        {
            return Math.Pow(_a, 2);
        }
    }

    class Isosceles : Figure //равнобедренный
    {
        protected int _a, _b, _c;
        protected double _h;
        public Isosceles(int a, int b, int c)
        {
            _a = a; _b = b; _c = c;
            _h = Math.Pow(a*a - c/2, 0.5);
        }
        public override double Square()
        {
            return _c * _h / 2;
        }
    }

    class Degree90 : Figure //прямоугольный
    {
        protected int _a, _b, _c;
        public Degree90(int a, int b, int c)
        {
            _a = a; _b = b; _c = c;
        }
        public override double Square()
        {
            return _c * _a / 2;
        }
    }

    class Right : Figure //равносторонний
    {
        protected int _a;
        public Right(int a)
        {
            _a = a;
        }
        public override double Square()
        {
            return _a * _a * Math.Pow(3,0.5) / 4;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures = { new Rectangle(2,3), new Triangle(2,5,4), new SquareR(5), new Isosceles(3,3,4), new Degree90(3,4,5), new Right(6) };

            foreach (Figure f in figures)
            {
                Console.WriteLine($"Площадь {f.GetType().ToString().PadRight(20)} {f.Square()}");
            }

            Console.ReadKey();
        }
    }
}
