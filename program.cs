using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static void PrintEven(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static int SumOfOdd(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    sum += i;
                }               
            }
            return sum;
        }

        static void Main(string[] args)
        {            
            object a = new object();
            //int sum = 0;
            //for (int i = 0; i < 100; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }                    
            //    else
            //    {
            //        sum += i;
            //    }          
            //}
            //Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Invoke Sum method: {Sum(5, 3)}\nInvoke SumOfOdds:  {SumOfOdd(100)}");
            PrintEven(100);
            Console.WriteLine($"Hash Code of object a: {a.GetHashCode()}");
            Console.ReadKey();
        }
    }
}
