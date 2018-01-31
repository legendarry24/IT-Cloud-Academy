using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(TestMethod);
            t.IsBackground = true;
            t.Start();
            Thread.Sleep(50);
            t.Join();

            Thread t1 = new Thread(TestMethod1);
            Thread t2 = new Thread(TestMethod2);
            t1.Priority = ThreadPriority.Lowest;
            t2.Priority = ThreadPriority.Highest;
            t1.Start(100);
            t2.Start(50);
            t2.Join();

            Console.WriteLine($"Thread context: {Thread.CurrentContext}\nCurrent domain: {Thread.GetDomain()}" +
                              $"Base directory: {Thread.GetDomain().BaseDirectory}");
            
            Console.WriteLine("============FINISH!!!=============");
        }

        static void TestMethod()
        {
            Console.WriteLine("Start new Thread!");
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine("\nFinish Thread");
        }

        static void TestMethod1(object start)
        {
            int x = (int)start;
            for (int i = 0; i < x; i++)
            {
                Console.Write(1);
            }
            Console.WriteLine();
        }

        static void TestMethod2(object start)
        {
            int x = (int)start;
            for (int i = 0; i < x; i++)
            {
                Console.Write(2);
            }
            Console.WriteLine();
        }
    }
}
