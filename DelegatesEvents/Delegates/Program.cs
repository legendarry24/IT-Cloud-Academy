using System;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        public delegate double SumDelegate(double a, double b);

        static double SumObjects(double a, double b)
        {
            Console.WriteLine(nameof(SumObjects));
            return a + b;
        }

        static double Add(double x, double y)
        {
            Console.WriteLine(nameof(Add));
            return x + y;
        }

        //delegate as parameter
        static void MyMethod(string a, SumDelegate sumDelegate)
        {

        }
       

        static void Main(string[] args)
        {
            #region Custom delegate
            //var sumDelegate = new SumDelegate(SumObjects);
            SumDelegate sumDelegate = SumObjects;
            sumDelegate += Add;
            sumDelegate += SumObjects;
            sumDelegate += Add;
            sumDelegate += Test.AddNumbers;

            SumDelegate delegate2 = Test.AddNumbers;
            delegate2 += SumObjects;

            sumDelegate += delegate2;

            foreach (var sum in sumDelegate.GetInvocationList())
            {
                Console.WriteLine(sum.DynamicInvoke(9, 3));
            }

            Console.WriteLine(sumDelegate(4, 5));
            //or
            Console.WriteLine(sumDelegate.Invoke(4, 5));
            #endregion

            #region Func and Action

            Action<string> action = Console.WriteLine;
            action += Console.WriteLine;
            action += (string a) =>
            {
                foreach (var symbol in a)
                {
                    Console.WriteLine(symbol);
                }
            };

            action.Invoke("Hello");

            Func<double, double, double> func = Add;

            func += SumObjects;
            func += Add;
            func += SumObjects;

            foreach (var sum in func.GetInvocationList())
            {
                Console.WriteLine(sum.DynamicInvoke(9, 3));
            }

            #endregion

            Console.ReadKey();
        }
    }
}
