using System;
using System.Diagnostics;
using System.Threading;

namespace MultiThreading2
{
    class Program
    {
        static double[] result = new double[1000000];
        static Thread[] arrayThread;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Stopwatch st = new Stopwatch();
            st.Start();

            //Thread t1 = new Thread(Fill);
            //Thread t2 = new Thread(Fill);
            //t1.Start(0);
            //t2.Start(1);

            //t1.Join();
            //t2.Join();
                        
            arrayThread = new Thread[count];

            for (int i = 0; i < arrayThread.Length; i++)
            {
                arrayThread[i] = new Thread(Fill);
                arrayThread[i].Start(i);
                arrayThread[i].Join();
            }

            st.Stop();
            Console.WriteLine(new string('+', 20));
            Console.WriteLine($"Elapsed time: {st.ElapsedMilliseconds} mc");

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }

        static void Fill(object x)
        {
            int part = (int)x;
            // if length == 100
            // x = 0 => part = 0 or x = 1 => part = 50
            //int startIndex = (result.Length / 2) * part;
            //int endIndex = startIndex + result.Length / 2;
            int startIndex = (result.Length / arrayThread.Length) * part;
            int endIndex = (startIndex + result.Length) / arrayThread.Length;

            Random rand = new Random();
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = rand.NextDouble();
            }
        }
    }
}
