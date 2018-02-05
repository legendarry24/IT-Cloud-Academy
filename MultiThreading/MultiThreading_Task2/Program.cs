using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading_Task2
{
    class Program
    {
        static List<int> list = new List<int>();
        static ConcurrentBag<int> concurrentList = new ConcurrentBag<int>();

        static void Main(string[] args)
        {
            #region Task
            Console.WriteLine("Start Main");

            CancellationTokenSource tokenSourse = new CancellationTokenSource();

            Task task = new Task(DoSmth, tokenSourse.Token, tokenSourse.Token);
            task.Start();
            Thread.Sleep(500);

            try
            {
                tokenSourse.Cancel();
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(task.IsFaulted);
                if (task.IsCanceled)
                    Console.WriteLine("Task is canceled");
            }
            finally
            {
                task.Dispose();
                tokenSourse.Dispose();
            }

            Console.WriteLine(task.IsCanceled);
            Console.WriteLine(task.IsFaulted);

            Console.WriteLine("End Main");
            #endregion

            #region Parallel
            Parallel.Invoke(
                    () => { Console.WriteLine("Method 1"); },
                    () => { Console.WriteLine("Method 2"); },
                    () => { Console.WriteLine("Method 3"); }
                );

            int size = 10000000;
            Stopwatch sw = Stopwatch.StartNew();
            
            //Parallel.For(0, size, x => list.Add(x));
            Parallel.For(0, size, x => concurrentList.Add(x));
            sw.Stop();
            //Console.WriteLine(list.Count);
            Console.WriteLine(concurrentList.Count);
            Console.WriteLine($"Parallel {size} elements: {sw.ElapsedMilliseconds}");

            sw.Restart();
            //the same but synchronously
            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }
            sw.Stop();
            Console.WriteLine(list.Count);
            Console.WriteLine($"Synchronously {size} elements: {sw.ElapsedMilliseconds}");

            Thread.Sleep(2000);

            Parallel.ForEach(new List<int> { 1, 3, 5, 6, 9, 11, 13 }, Test);

            list.Where(x => x == 2).AsParallel();
            #endregion

            Interlocked.Exchange(ref size, size / 2);
            Interlocked.Increment(ref size);
            Console.WriteLine(size);

            Console.ReadKey();
        }

        static void Test(int x, ParallelLoopState state)
        {
            if (x == 6)
            {
                state.Break();
            }
            Thread.Sleep(1000);
            Console.WriteLine(x);
        }

        static void DoSmth(object o)
        {
            CancellationToken token = (CancellationToken)o;
            //finish the task if it was canceled before it was started
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Start new Task. Task id: {Task.CurrentId}");           

            for (int i = 0; i < 10; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Task was canceled");
                    return;                                     
                }
                Thread.Sleep(100);
                Console.WriteLine(i);

                //try
                //{
                //    token.ThrowIfCancellationRequested();

                //    Console.WriteLine(i);
                //    Thread.Sleep(100);
                //}
                //catch (OperationCanceledException)
                //{
                //    Console.WriteLine(token.IsCancellationRequested);
                //}
            }

            Console.WriteLine("End new Task");
        }
    }
}
