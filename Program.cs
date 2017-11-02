using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1 - dimensional array

            int[] arr = new int[3];
            //arr[0] = 1;
            //arr[2] = 3;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write($"{arr[i]} ");
            //}

            //Console.Write("\nInput array length: ");
            //int n = int.Parse(Console.ReadLine());
            //arr = new int[n];
            //Console.WriteLine("Initialize an array: ");
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            //for (int i = arr.Length - 1; i >= 0; i--)
            //{
            //    Console.Write($"{arr[i]} ");
            //}

            #endregion

            #region n - dimensional array

            //int[,] arr2 = new int[5, 3];
            //int[,,] arr3 = new int[3, 2, 4];

            //for (int i = 0; i < arr2.GetLength(0); i++) // length of first dimension (now returns 5)
            //{
            //    for (int j = 0; j < arr2.GetLength(1); j++) // length of second dimension (now returns 3)
            //    {
            //        Console.WriteLine($"i = {i}, j = {j}");
            //    }
            //}

            #endregion

            #region jugged array

            //int[][] jugArr = new int[4][];
            //jugArr[0] = new int[2];
            //jugArr[1] = new int[3];
            //jugArr[2] = new int[4];
            //jugArr[3] = new int[1];

            //for (int i = 0; i < jugArr.Length; i++)
            //{
            //    Console.WriteLine(jugArr[i].Length);
            //}

            #endregion

            #region output even numbers, then odd numbers

            arr = new int[] { 1, 3, 54, 7, 78, 897, 4 };

            // with 2 loops
            //for (int i = 0; i < arr.Length; i += 2)
            //{
            //    Console.WriteLine($"[{i}] -> {arr[i]} ");
            //}

            //for (int i = 1; i < arr.Length; i += 2)
            //{
            //    Console.WriteLine($"[{i}] -> {arr[i]} ");
            //}

            // with 1 loop
            //for (int i = 0;; i += 2)
            //{
            //    if (i > arr.Length)
            //    {
            //        i = 1;
            //    }
            //    if (i + 1 > arr.Length )
            //    {
            //        break;
            //    }
            //    Console.WriteLine($"[{i}] -> {arr[i]} ");               
            //}

            //with 1 loop (advanced)
            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i * 2 < arr.Length)
                {
                    Console.WriteLine($"[{i * 2}] -> {arr[i * 2]}");
                }
                else
                {
                    // (arr.Length - 1) % 2) returns 1 if length of array is even otherwise returns 0
                    int index = (i * 2 + (arr.Length - 1) % 2) % arr.Length;
                    Console.WriteLine($"[{index}] -> {arr[index]}");
                }
            }

            watch.Stop();
            TimeSpan timeSpan = watch.Elapsed;
            Console.WriteLine($"Time: {timeSpan.Minutes}m {timeSpan.Seconds}s {timeSpan.Milliseconds}ms");

            #endregion

            //int[] a1 = new int[] { 1, 2, 3, 4 };
            //int[] a2 = a1;
            //a2[0] = 5;
            //a2 = new int[] { 7, 8, 9 };
            //Console.WriteLine($"a1[0] = {a1[0]}, a2[0] = {a2[0]}\n"); // a1[0] = 5 cuz Array is ref type

            //int[] a3 = new int[a1.Length];
            //Array.Copy(a1, a3, a1.Length);
            //for (int i = 0; i < a3.Length; i++)
            //{
            //    Console.Write(a3[i]);
            //}

            // in order to increase number of elements of an array in runtime
            //int[] myArr = new int[5] { 1, 2, 3, 4, 5};
            //int[] temp = new int[5];
            //Array.Copy(myArr, temp, myArr.Length);
            //myArr = new int[6];
            //Array.Copy(temp, myArr, temp.Length);
            //for (int i = 0; i < myArr.Length; i++)
            //{
            //    Console.Write($"{myArr[i]} ");
            //}
            Console.ReadKey();
        }
    }
}
