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

        static void Main(string[] args)
        {
            // Task 1 factorial
            Console.Write("Input n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"{n}! = {Fact(n)}");

            // Task 2 sum of even
            Console.Write("Input n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Sum of row 2 + 4 + ... + 2n = {SumOfEven(n)}");

            // Task 3 Print rectangle
            int a = 3, b = 4;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write('*');
                }
                Console.Write('\n');
            }
            Console.Write('\n');

            // Task 4 Print rectangle
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if ((i == 1) && (j == 1 || j == 2))
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write('*');
                    }                    
                }
                Console.Write('\n');
            }

            Console.ReadKey();
        }

    }
}
