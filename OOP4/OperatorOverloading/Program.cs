using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point
            {
                X = 2,
                Y = 1,
                IsDrawed = true
            };

            var p2 = new Point
            {
                X = 3,
                Y = 4
            };
            Point p3 = p1 + p2;
            Console.WriteLine(p3);
            p3 -= p1;
            Console.WriteLine(p3);
            Console.WriteLine(p3++);
            Console.WriteLine(p3 > p2);
            Console.WriteLine(p3 < p2);
            if (p1)
            {
                Console.WriteLine(p1);
            }

            if (p2)
            {
                Console.WriteLine(p2);
            }

            double d = p1;
            float f = (float)p1;
            Console.ReadKey();
        }
    }
}
