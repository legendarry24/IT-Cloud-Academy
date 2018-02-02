using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t = new Task(() => Console.WriteLine("Do smth"));
            //t.Start();

            ////the same
            //Task t1 = Task.Factory.StartNew(() => Console.WriteLine("Do smth2"));

            //Task t2 = Task.Run(() => Console.WriteLine("Do smth3"));

            //t1.Wait();

            //Task[] array = new Task[100];
            //Task.WaitAll(array);

            Task parent = Task.Factory.StartNew(() => 
            { 
                Console.WriteLine("Parent task starting...");

                var inner = Task.Factory.StartNew(() => 
                { 
                    Console.WriteLine("Inner task starting...");
                    Task.Delay(100);
                    Console.WriteLine("Inner task finished...");
                }, TaskCreationOptions.AttachedToParent);
                               
                Console.WriteLine("Parent task finished...");
            });
            parent.Wait();

            Task<int> genericTask = new Task<int>(() => Test(5));
            genericTask.Start();
            Console.WriteLine(genericTask.Result);

            Console.WriteLine("End Main");
            Console.ReadKey();
        }

        static int Test(int x)
        {
            return x * 10;
        }
    }
}
