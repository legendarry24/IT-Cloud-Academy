using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen
{
    class Program
    {
        static void Main(string[] args)
        {
            var pens = new PensRepository(25);
            var pen = new Pen
            {
                Id = 1,
                Brand = "Axe",
                Price = 20,
                Size = 10
            };
            var pen1 = new Pen();
            var pen2 = new Pen
            {
                Id = 3,
                Brand = "Foo",
                Price = 10,
                Size = 14
            };
            Pen pen3 = null;
            pens.Add(pen);
            pens.Add(pen1);
            pens.Add(pen2);
            pens.Delete(1);
            pens.Delete(3); // Index out of range
            pens.Add(pen3); // Invalid input parameter
            //Console.WriteLine(pens[3].ToString()); // Null reference exception
            Pen pen4 = pens.Get(1);
            Console.WriteLine(pen4.ToString());
            Pen pen5 = pens.Get(5);
            Pen pen6 = pens.Get(-1);
            //Console.WriteLine(pen5.ToString()); // Null reference exception
            //Console.WriteLine(pen6.ToString()); // Null reference exception

            Console.WriteLine($"Amount of elements: {pens.Count}");
            for (int i = 0; i < pens.Count; i++)
            {
                Console.WriteLine(pens[i].ToString());
                Console.WriteLine(new string('*', 30));
            }

            Console.ReadKey();
        }
    }
}
