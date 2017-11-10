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
        static void Test(object o)
        {
            Console.WriteLine("Object method");
        }
        static void Test(ValueType value)
        {
            Console.WriteLine("ValueType method");
        }
        static void Test(int a)
        {
            Console.WriteLine("int method");
        }

        static int FibanachiRecursive(int n)
        {
            if (n < 2)
            {
                return n == 1 ? 1 : 0;
            }
            return FibanachiRecursive(n - 2) + FibanachiRecursive(n - 1);
        }

        static int Fibonachi(int n)
        {
            int f0 = 0, f1 = 1;
            int fn = n == 1? 1: 0;
            for (int i = 2; i <= n; i++)
            {
                fn = f0 + f1;
                f0 = f1;
                f1 = fn;
            }
            return fn;
        }

        static void Main(string[] args)
        {
            //MyClass test = new MyClass(2, 3);
            //Test(1);
            //Test(0.23);
            //Test(null);
            //Test("sample text");

            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine($"{n}th number of Fibonachi = {Fibonachi(n)} ");
            //Console.WriteLine($"{n}th number of Fibonachi = {FibanachiRecursive(n)} ");

            Human human = new Human(DateTime.Now);
            human.Walk();

            Console.ReadKey();
        }
    }
}
