using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading3
{
    class Program
    {
        static int[] array;
        static int count = 0;
        static object syncThread = new object();

        static void Main(string[] args)
        {
            array = new int[100000];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 10);
            }

            Thread t1 = new Thread(Sum);
            Thread t2 = new Thread(Sum);

            t1.Start(0);
            t2.Start(1);

            t1.Join();
            t2.Join();
            Console.WriteLine("After joins");
            Console.WriteLine(count);

            int sumWithoutThreading = array.Sum();
            Console.WriteLine(sumWithoutThreading);
        }

        static void Sum(object partObj)
        {
            int part = (int)partObj;

            int startIndex = array.Length / 2 * part;
            int endIndex = startIndex + array.Length / 2;

            for (int i = startIndex; i < endIndex; i++)
            {
                lock (syncThread)
                {
                    count += array[i];
                }

                //the same
                //try
                //{
                //    Monitor.Enter(syncThread);
                //    count += array[i];
                //}
                //finally
                //{
                //    Monitor.Exit(syncThread);
                //}

                //Thread.Sleep(5);
            }
        }
    }
}
