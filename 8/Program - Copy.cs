using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    public struct Coords
    {
        public int x;
        public int y;
        public char hemisphere;

        public override string ToString()
        {
            return $"{hemisphere.ToString().ToUpper()} ({x}, {y})";
        }
    }
    class Ship
    {
        private readonly string _number;
        private Coords _coords;

        public string Number
        {
            get { return _number; }
        }
        public Coords Coords
        {
            get { return _coords; }
            set { _coords = value; }
        }

        public Ship(string number)
        {
            _number = number;
            _coords = new Coords() { x = 0, y = 0, hemisphere = 'n' };
        }

        public double Distance(Ship ship)
        {
            if (ship.Coords.hemisphere == _coords.hemisphere) return Math.Pow(Math.Pow(_coords.x - ship.Coords.x, 2) + Math.Pow(_coords.y - ship.Coords.y, 2), 0.5);
            
            return Math.Pow(Math.Pow(_coords.x - ship.Coords.x, 2) + Math.Pow(_coords.y - ship.Coords.y, 2), 0.5) * 2;
        }
    }
    internal class Program2
    {
        static void Main(string[] args)
        {
            a:
            try
            {
                string[] temp;
                Console.WriteLine("Введите номер первого корабля");
                Ship ship = new Ship(Console.ReadLine());
                Console.WriteLine("Введите координаты в формате: [X] [Y] [Полушарие (n или s)]");
                temp = Console.ReadLine().Split(' ').ToArray();
                ship.Coords = new Coords()
                {
                    x = Convert.ToInt32(temp[0]),
                    y = Convert.ToInt32(temp[1]),
                    hemisphere = Convert.ToChar(temp[2]),
                };

                Console.WriteLine("Введите номер второго корабля");
                Ship ship2 = new Ship(Console.ReadLine());
                Console.WriteLine("Введите координаты в формате: [X] [Y] [Полушарие (n или s)]");
                temp = Console.ReadLine().Split(' ').ToArray();
                ship.Coords = new Coords()
                {
                    x = Convert.ToInt32(temp[0]),
                    y = Convert.ToInt32(temp[1]),
                    hemisphere = Convert.ToChar(temp[2]),
                };

                Console.WriteLine($"Расстояние между кораблями: {ship.Distance(ship2)}");
                Console.ReadKey();
            }
            catch (Exception)
            {

                goto a;
            }
            
        }
    }
}
