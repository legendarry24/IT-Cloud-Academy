using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_algorithms
{
    class Program
    {
        public static int LastDigit(int number)
        {
            return number % 10;
        }
        static void Main(string[] args)
        {
            #region Task 1: return last digit

            Console.WriteLine("1. Return last digit\n");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"{num} -> {LastDigit(num)}");

            #endregion

            #region Task 2: input numbers until -1 is entered, if -1 is entered => return sum of previous numbers 

            Console.WriteLine("\n2. Input numbers until -1 is entered, if -1 is entered => return sum of previous numbers\n");
            int sum = 0;
            while (true)
            {
                num = int.Parse(Console.ReadLine());
                if (num == -1)
                {
                    Console.WriteLine(sum);
                    break;
                }
                else
                {
                    sum += num;
                }
            }

            #endregion

            #region Task 3: Print numbers from 10 to 20 in reversed order

            Console.WriteLine("\n3. Print numbers from 10 to 20 in reversed order\n");
            for (int i = 20; i >= 10; i--)
            {
                Console.WriteLine($"{i} ");
            }

            #endregion

            #region Task 4: input number and print all of its digits separatelly

            Console.WriteLine("\n4. Input number and print all of its digits separatelly\n");
            num = int.Parse(Console.ReadLine());
            int divisor = 1, countOfDigits = 0;

            while (num / divisor > 0)
            {
                divisor *= 10;
                countOfDigits++;
            }
            divisor /= 10;

            for (int i = 0; i < countOfDigits; i++)
            {
                Console.Write($"{num / divisor} ");
                num -= num / divisor * divisor;
                divisor /= 10;
            }

            #endregion

            #region Task 5: input number and print it in reversed order

            Console.WriteLine("\n\n5. Input number and print it in reversed order\n");
            num = int.Parse(Console.ReadLine());
            while (num != 0)
            {
                Console.Write(num % 10);
                num /= 10;
            }

            #endregion

            #region Task 6: find and print sum of numbers digits

            Console.WriteLine("\n\n6. Find and print sum of numbers digits\n");
            num = int.Parse(Console.ReadLine());
            sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine(sum);

            #endregion

            #region Task 7: Print separately a fractional, an integer part of a number

            Console.WriteLine("\n7. Print separately a fractional, an integer part of a number\n");
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine($"Integer part of the number: {number - number % 1}" // another way: Math.Truncate(number)
                            + $"\nfractional part of the number: {number % 1}");

            #endregion

            Console.ReadKey();
        }
    }
}
