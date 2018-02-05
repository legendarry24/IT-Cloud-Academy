using System;
using System.Threading;

namespace MultiThreading_Mutex
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isNotRunning;

            Mutex m = new Mutex(true, "MyMutex", out isNotRunning);

            if (isNotRunning)
            {
                Console.WriteLine("Start!");
            }
            else
            {
                Console.WriteLine("Already working!");
                Console.ReadKey();
                return;
            }

            TimerCallback callback = Test;
            Timer t = new Timer(callback, null, 0, 1000);

            //timer will be working until key is pressed
            Console.ReadKey();
        }

        static void Test(object obj)
        {
            Console.WriteLine("Do it...");
        }
    }
}
