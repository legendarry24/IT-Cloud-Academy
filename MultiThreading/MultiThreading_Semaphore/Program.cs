using System;
using System.Threading;

namespace MultiThreading_Semaphore
{
    class Program
    {
        static Thread[] threads = new Thread[10];
        static Semaphore sem = new Semaphore(2, 3);

        static void ElevatorRun()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting in line...");
            sem.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} enters the elevator");
            Thread.Sleep(300);
            Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the elevator");
            sem.Release();
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(ElevatorRun);
                threads[i].Name = "thread_" + i;
                threads[i].Start();
            }

            Console.ReadKey();
        }
    }
}
