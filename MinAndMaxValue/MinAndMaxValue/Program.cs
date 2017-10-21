using System;

namespace MinAndMaxValue
{
    class Program
    {
        static int MinValue(int a, int b, int c)
        {
            if (a > b)
            {
                return b > c ? c : b;
            }
            else
            {
                return a > c ? c : a;
            }    
        }

        static int MaxValue(int a, int b)
        {
            return a > b ? a : b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 values:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine($"Min value: {MinValue(a, b, c)}");
            Console.WriteLine("Enter 2 values:");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Max value: {MaxValue(a, b)}");
            Console.ReadKey();
        }
    }
}