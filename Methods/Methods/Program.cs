using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static int Fact(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            } 
            else
            {
                return n * Fact(n - 1);
            }            
        }
    
        static int SumOfEven(int n)
        {
            int sum = 0;
            for (int i = 2; i <= 2 * n; i += 2)
            {
                sum += i;
            }
            return sum;
        }

        static void PrintFilledRect(int a, int b)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write('*');
                }
                Console.Write('\n');
            }
            Console.Write('\n');
        }

        static void PrintRect(int a, int b)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (i == 0 || i == a - 1)
                    {
                        Console.Write('*');
                    } else
                    {
                        Console.Write('*' + new string(' ', b - 2) + '*');
                        break;
                    }
                }
                Console.Write('\n');
            }
        }

        static void SomeMethod(int[] array)
        {
            array = new int[10];
        }

        static void SomeMethod(ref int[] array)
        {
            array = new int[10];
        }

        static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        static int Test(params int[] array) // as many parameters as we want
        {
            return array[1];
        }

        static bool MyMethod(int divisor, params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % divisor != 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            // Task 1 factorial
            Console.Write("Input n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"{n}! = {Fact(n)}");

            // Task 2 sum of even
            Console.Write("Input n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Sum of row 2 + 4 + ... + 2n = {SumOfEven(n)}\n");

            // Task 3 Print filled rectangle
            int a = 5, b = 7;
            PrintFilledRect(a, b);

            // Task 4 Print rectangle
            PrintRect(a, b);

            int[] arr = { 1, 2, 3, 4 };

            SomeMethod(arr);
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }

            SomeMethod(ref arr);
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Max of {a} and {b} is {Max(a, b)}");

            Console.WriteLine(Test(1, 2, 3, 4, 5));

            Console.WriteLine(MyMethod(2, 4, 6, 8, 9));

            Console.ReadKey();
        }

    }
}
