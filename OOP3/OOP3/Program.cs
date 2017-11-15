using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            var pen = new Pen("BIC");
            pen.Manufacturer = "MaxRighter";
            Console.WriteLine(pen.Manufacturer);

            var pencils = new Pencils(24);            
            pencils[2] = new Pencil
            {
                Brand = "Castel",
                Price = 25
            };

            var pencil = pencils[2];
            Console.ReadKey();
        }
    }
}
