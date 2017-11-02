using System;
using System.Collections.Generic;
using System.Linq;

namespace Loops_and_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.
            Console.WriteLine("1. Print numbers from 0 to 10\n");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            // 2.
            Console.WriteLine("\n2. Print numbers from 100 to 200\n");
            for (int i = 100; i <= 200; i++)
            {
                Console.WriteLine(i);
            }

            // 2.1
            Console.WriteLine("\n2.1 Print numbers from 100 to 200 in reverse order\n");
            for (int i = 200; i >= 100; i--)
            {
                Console.WriteLine(i);
            }

            // 3.
            Console.WriteLine("\n3. Print even only from 0 to 50\n");
            for (int i = 0; i <= 50; i += 2)
            {
                Console.WriteLine(i);
            }

            // 4.
            Console.WriteLine("\n4. Find and print the sum of numbers from 0 to 100\n");
            int sum = 0;
            for (int i = 0; i <= 100; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);

            // 5.
            Console.WriteLine("\n5. Find and print the product of numbers from 1 to 10\n");
            sum = 1;
            for (int i = 2; i <= 10; i++) // first iterate will be 1 * 2
            {
                sum *= i;
            }
            Console.WriteLine(sum);

            // 6.
            Console.WriteLine("\n6. Input the number and print all of its digits separately\n");
            char[] digits = Console.ReadLine().ToCharArray();
            foreach (char digit in digits)
            {
                Console.Write($"{digit} ");
            }

            // 6.1
            Console.WriteLine("\n6.1 Print separately a fractional, an integer part of a number\n");
            //double num = double.Parse(Console.ReadLine());
            //Console.WriteLine($"The integer part of a number: {Math.Truncate(num)}" +
            //                   $"\nthe fractional part of a number: {num % 1}");
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine($"Your number is {number}");
            Console.WriteLine($"integer part: {number - number % 1}");
            float fract = (float)(number % 1); //(float) (number - Math.Truncate(number));  // get fractional part
            int multiplayer = 10;
            while (fract % 1 != 0)
            {
                fract *= multiplayer;
            }
            Console.WriteLine($"fractional part: {fract}");

            // 7.
            Console.WriteLine("\n7. Find and print the sum of the digits of a number\n");
            int num = int.Parse(Console.ReadLine());
            sum = 0;
            while (num > 0)
            {
                int tmp = num % 10;
                sum += tmp;
                num /= 10;
            }
            Console.WriteLine(sum);

            // 8.
            Console.WriteLine("\n8. Input a string, output it in reverse\n");
            string str = Console.ReadLine();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i]);
            }
            // another way with Linq
            // char[] str = Console.ReadLine().ToCharArray().Reverse().ToArray();
            // Console.WriteLine(str);

            // 9. 
            Console.WriteLine("\n9. Declare an array of 10 elements, fill it with elements from 0 to 9 and output\n");
            int[] arr = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            // 10.   
            Console.WriteLine("\n10. input size of an array, input the int array\n");
            Console.Write("Enter size: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr2 = new int[n];
            Console.WriteLine("Fill array: ");
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(new string('-', 10));
            foreach (int i in arr2)
            {
                Console.WriteLine(i);
            }

            // 11. 
            Console.WriteLine("\n11. Find sum of elements of an array\n");
            sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            Console.WriteLine(sum);

            // 12. 
            Console.WriteLine("\n12. Find product of elements of an array\n");
            sum = 1;
            for (int i = 2; i < arr.Length; i++)
            {
                sum *= i;
            }
            Console.WriteLine(sum);

            // 13. 
            Console.WriteLine("\n13. Find min element of an array\n");
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            Console.WriteLine(min);

            // 14. 
            Console.WriteLine("\n14. Find max element of an array\n");
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine(max);

            // 15. 
            Console.WriteLine("\n15. Find the arithmetic mean of array elements\n");
            sum = arr.Sum();  // Linq 
            Console.WriteLine((float)sum / arr.Length);

            // 16. 
            Console.WriteLine("\n16. Swap min and max elements of an array\n");
            int indexMin = 0, indexMax = 0;
            max = arr[0]; min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    indexMin = i;
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                    indexMax = i;
                }
            }
            arr[indexMin] = max;
            arr[indexMax] = min;

            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }

            // 17. 
            Console.WriteLine("\n17. Input size of two arrays, compare them element by element\n");
            Console.WriteLine("Enter sizes of arrays: ");
            n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int matches = 0;
            int[] arr3 = new int[n], arr4 = new int[m];
            Random rand = new Random();
            for (int i = 0; i < arr3.Length && i < arr4.Length; i++)
            {
                arr3[i] = rand.Next(0, 5);
                arr4[i] = rand.Next(0, 10);
            }
            for (int i = 0; i < arr3.Length && i < arr4.Length; i++)
            {
                if (arr3[i] == arr4[i])
                {
                    matches++;
                }
            }
            Console.Write("First array:  ");
            for (int i = 0; i < arr3.Length; i++)
            {
                Console.Write($"{arr3[i]} ");
            }
            Console.Write("\nSecond array: ");
            for (int i = 0; i < arr4.Length; i++)
            {
                Console.Write($"{arr4[i]} ");
            }
            Console.WriteLine($"\nAmount of identical elements: {matches}");

            // 18. 
            Console.WriteLine("\n18. Double the value of all array elements\n");
            foreach (int i in arr)
            {
                arr[i] *= 2;
                Console.Write($"{arr[i]} ");
            }

            // 19. 
            Console.WriteLine("\n19. Input string array with fixed size. Input one more string (mask).\n"
                            + "Print all the strings which contain mask and index off the beginning of the substring\n");
            string[] strArray = new string[3];
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = Console.ReadLine();
            }
            Console.Write("input the mask: ");
            string mask = Console.ReadLine();
            foreach (string s in strArray)
            {
                if (s.Contains(mask))
                {
                    Console.WriteLine($"{s}. Index of mask is {s.IndexOf(mask[0])}");
                }
            }

            // 20. 
            Console.WriteLine("\n20. Input string array with fixed size. Input one more string (mask)."
                            + "Delete mask from all the strings\n");
            strArray = new string[4];
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = Console.ReadLine();
            }
            Console.Write("input the mask: ");
            mask = Console.ReadLine();
            Console.WriteLine("Mask has been deleted!");
            foreach (string s in strArray)
            {
                if (s.Contains(mask))
                {
                    Console.WriteLine(s.Replace(mask, string.Empty));
                }
            }

            // additional task
            Console.WriteLine("\nInput numbers until non number is entered and fill an array. " +
                              "Initial size of the array is 1. When the array is completely filled it needs to be expanded by 1 element" +
                              " and then repeat input. After non number is entered - output the array\n");
            int[] array = new int[1];
            List<int> tempList = new List<int>();
            int temp;

            while (int.TryParse(Console.ReadLine(), out temp))
            {
                tempList.Add(temp);
            }

            Array.Resize(ref array, tempList.Count);
            array = tempList.ToArray();            
            array = new int[array.Length + 1];
            Console.WriteLine("Repeat input:");

            for (int i = 0; i < array.Length; i++)
            {
                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    array[i] = temp;
                }
                else
                {
                    break;
                }
            }

            foreach (int element in array)
            {
                Console.Write($"{element} ");
            }

            // 21. 
            Console.WriteLine("\n21. Create an array with unique elements from 0 to 10 in random order\n");
            int[] uniqArr = Enumerable.Range(0, 11).OrderBy(x => rand.Next()).ToArray();
            foreach (int i in uniqArr)
            {
                Console.Write($"{uniqArr[i]} ");
            }

            // or alternatively
            //Console.WriteLine("\nAnother implementation: ");
            //HashSet<int> randomSet = new HashSet<int>();
            //while (randomSet.Count < 11)
            //{
            //    randomSet.Add(rand.Next(0, 11));
            //}
            //Console.Write(string.Join(" ", randomSet));

            // 22. 
            Console.WriteLine("\n22. Create struct that describes the playing card\n");
            Card card = new Card(Number.Ace, Suit.hearts);
            Console.WriteLine($"{card.Number} of {card.Suit}");

            Console.ReadKey();
        }
    }
}
