using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading_Test
{
    class Program
    {
        static Action[] methods;

        static void Main(string[] args)
        {
            methods = new Action[] { Method1, Method2, Method3 };

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"If you want to execute method {i + 1} then click {i + 1}");
            }
            int choice = int.Parse(Console.ReadLine());
            MethodCall(choice);

            Console.ReadKey();
        }

        static void MethodCall(int number)
        {
            Thread thread = new Thread(methods[number - 1].Invoke);
            thread.Start();
        }

        static void Method1()
        {
            Console.WriteLine("Begin 1");
            Thread.Sleep(5000);
            Console.WriteLine("End 1");
        }

        static void Method2()
        {
            Console.WriteLine("Begin 2");
            Thread.Sleep(5000);
            Console.WriteLine("End 2");
        }

        static void Method3()
        {
            Console.WriteLine("Begin 3");
            Thread.Sleep(5000);
            Console.WriteLine("End 3");
        }

    }
}
