using System;
using System.Threading.Tasks;

namespace MultiThreading_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task(() => Console.WriteLine("Do smth"));
            t.Start();

            //the same
            Task t1 = Task.Factory.StartNew(() => Console.WriteLine("Do smth2"));

            Task t2 = Task.Run(() =>
            {
                Task.Delay(1000);
                Console.WriteLine("Do smth3");
            });

            t2.Wait();

            //Task[] array = new Task[100];
            //Task.WaitAll(array);

            Task outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task starting...");

                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner task starting...");
                    Task.Delay(100);
                    Console.WriteLine("Inner task finished...");
                }, TaskCreationOptions.AttachedToParent);
                //inner.Wait();
                Console.WriteLine("Outer task finished...");
            });
            outer.Wait();

            Task<int> genericTask = new Task<int>(() => Test(5));
            genericTask.Start();
            genericTask.ContinueWith(ContinueTask);
            Console.WriteLine(genericTask.Result);

            Task task = new Task(() => { throw new Exception(); });
            try
            {
                task.Start();
                task.Wait();
            }
            catch (AggregateException)
            {
                Console.WriteLine(task.IsFaulted);
                Console.WriteLine(task.Exception);
            }

            Console.WriteLine("End Main");
            Console.ReadKey();
        }

        static int Test(int x)
        {
            return x * 10;
        }

        static void ContinueTask(Task<int> task)
        {
            Console.WriteLine(task.Result * 10);
        }
    }
}
