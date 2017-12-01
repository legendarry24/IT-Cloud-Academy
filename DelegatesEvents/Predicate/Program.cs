using System;
using System.Collections.Generic;

namespace Predicate
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            Predicate<int> predicate = x => x % 2 == 0;

            bool boolResult = list.All(predicate);
            Console.WriteLine($"Result of All = {boolResult}\n{new string('-', 30)}");

            boolResult = list.Any(predicate);
            Console.WriteLine($"Result of Any = {boolResult}\n{new string('-', 30)}");

            int intResult = list.Count(predicate);
            Console.WriteLine($"Result of Count = {intResult}\n{new string('-', 30)}");

            Console.ReadKey();
        }

        
    }
}
//first, firstordefault, last, lastordefault