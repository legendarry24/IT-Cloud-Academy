using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    class Program
    {
        static void Main(string[] args)
        {
            // boxing / unboxing
            //int a = 5;
            //object o = a;
            //int b = (int)o;

            //var array = new ArrayList();
            //array.Add(a);

            var list = new List(1);
            list.Add(2);
            list.Add(5);
            list.Add(7);
            //list.Print();
            Console.WriteLine(list[1]);

            Console.ReadKey();
        }
    }
}
