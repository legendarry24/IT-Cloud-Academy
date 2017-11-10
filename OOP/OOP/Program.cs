using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("Without parameters");
        }
        public MyClass(int x): this()
        {
            Console.WriteLine("x");
        }
        public MyClass(int x, int y): this(x * y)
        {
            Console.WriteLine("x and y");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass test = new MyClass(2, 3);
            
            Console.ReadKey();
        }
    }
}
