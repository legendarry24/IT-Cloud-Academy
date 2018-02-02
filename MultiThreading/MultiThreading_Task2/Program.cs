using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading_Task2
{
    class Program
    {
        static List<int> list = new List<int>();

        static void Main(string[] args)
        {
            #region Task
            //Console.WriteLine("Start Main");

            //CancellationTokenSource tokenSourse = new CancellationTokenSource();

            //Task task = new Task(DoSmth, tokenSourse.Token);
            //task.Start();

            //try
            //{
            //    Thread.Sleep(500);
            //    tokenSourse.Cancel();
            //}
            //catch (AggregateException ex)
            //{
            //    Console.WriteLine(task.IsCanceled);
            //    Console.WriteLine(task.IsFaulted);
            //}

            //for (int i = 0; i < 100; i++)
            //{

            //}

            //Console.WriteLine("End Main"); 
            #endregion
            Parallel.For(0, 10000, (x) => list.Add(x));
            Console.WriteLine(list.Count());
        }

        static void DoSmth(object o)
        {
            Console.WriteLine("Start new Task");
            Console.WriteLine($"Task id: {Task.CurrentId}");
            CancellationToken token = (CancellationToken)o;

            for (int i = 0; i < 10; i++)
            {
                if (token.IsCancellationRequested)
                {
                    //token.ThrowIfCancellationRequested();
                    return;
                }
                Console.WriteLine(i);
                Thread.Sleep(100);
            }

            Console.WriteLine("End new Task");
        }
    }
}
