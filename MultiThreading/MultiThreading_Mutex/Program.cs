using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading_Mutex
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCreated = false;

            Mutex m = new Mutex(true, "test1", out isCreated);

            if (isCreated)
            {
                Console.WriteLine("Start!");
            }
            else
            {
                Console.WriteLine("Already working!");
                Console.ReadKey();
                return;
            }

            TimerCallback callback = new TimerCallback(Test);
            Timer t = new Timer(callback, null, 0, 1000);

            Console.ReadKey();
        }

        static void Test(object obj)
        {
            Console.WriteLine("Do smth");
        }
    }
}
