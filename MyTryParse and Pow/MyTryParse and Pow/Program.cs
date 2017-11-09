using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyTryParse_and_Pow
{
    class Program
    {
        static double MyPow(double x, double power)
        {
            double result = 1;
            if (power >= 1)
            {
                for (int i = 0; i < power; i++)
                {
                    result *= x;
                }
            }
            else if (power < 1)
            {
                for (int i = 0; i > power; i--)
                {
                    result *= 1.0 / x;
                }
            }
            return result;
        }
        static double FasterPow(double x, double y)
        {
            return Math.Exp(y * Math.Log(x));
        }

        static bool MyTryParse(string s, out int result)
        {
            result = 0;
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
                else
                {
                    result *= 10;
                    result += (int)char.GetNumericValue(c);  // c - '0'; it works too
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MyPow(2, 0));
            Console.WriteLine(MyPow(2, 5));
            Console.WriteLine(MyPow(2, -5));
            Console.WriteLine(MyPow(2, 0.5));   // not works(
            Console.WriteLine(FasterPow(2, 0.5));
            Console.WriteLine(Math.Pow(2, 0.5));

            int number;
            Console.WriteLine("\nInput a string to parse:");
            bool result = MyTryParse(Console.ReadLine(), out number);
            Console.WriteLine($"{result}\n{number}\n");
            char c = 'f';
            int a = c - '0';
            Console.WriteLine($"ASCII code of {c} is {a}");
            Console.ReadKey();
        }
    }
}
