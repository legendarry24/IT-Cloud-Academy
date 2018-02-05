using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace MultiThreading2
{
    class Program
    {
        static double[] _result = new double[100];
        static Thread[] _arrayThread;
        static double _min;
        static double _max;

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

            _arrayThread = new Thread[count];

            for (int i = 0; i < _arrayThread.Length; i++)
            {
                _arrayThread[i] = new Thread(Fill);
                _arrayThread[i].Start(i);
                _arrayThread[i].Join();
            }

            st.Stop();
            Console.WriteLine(new string('+', 20));
            Console.WriteLine($"Elapsed time: {st.ElapsedMilliseconds} mc");

            for (int i = 0; i < _arrayThread.Length; i++)
            {
                _arrayThread[i] = new Thread(FindMin);
                _arrayThread[i].Start();
                _arrayThread[i].Join();
            }

            Console.WriteLine($"Min element: {_min}");

            for (int i = 0; i < _arrayThread.Length; i++)
            {
                _arrayThread[i] = new Thread(FindMax);
                _arrayThread[i].Start();
                _arrayThread[i].Join();
            }

            Console.WriteLine($"Max element: {_max}");

            Print();
        }

        static void Fill(object x)
        {
            int part = (int) x;
            // if length == 100
            // x = 0 => part = 0 or x = 1 => part = 50
            //int startIndex = (result.Length / 2) * part;
            //int endIndex = startIndex + result.Length / 2;
            int startIndex = _result.Length / _arrayThread.Length * part;
            //if the last thread then go to the end of an array
            int endIndex = part == _arrayThread.Length - 1
                ? _result.Length
                : startIndex + _result.Length / _arrayThread.Length;

            Random rand = new Random();
            for (int i = startIndex; i < endIndex; i++)
            {
                _result[i] = rand.NextDouble();
                //Thread.Sleep(10);
            }
        }

        static void Print()
        {
            for (int i = 0; i < _result.Length; i++)
            {
                Console.WriteLine(_result[i]);
            }
        }

        static void FindMin()
        {
            _min = _result.Min();
        }

        static void FindMax()
        {
            _max = _result.Max();
        }
    }
}
