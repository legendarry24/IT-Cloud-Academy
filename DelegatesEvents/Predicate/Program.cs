using System;
using System.Collections.Generic;

namespace Predicate
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 1, 2, 4, 5, 9, 7 };
            Predicate<int> predicate = x => x % 2 == 0;

            Console.WriteLine($"Result of All = {list.All(predicate)}\n{new string('-', 30)}");
            Console.WriteLine($"Result of Any = {list.Any(predicate)}\n{new string('-', 30)}");
            Console.WriteLine($"Result of Count = {list.Count(predicate)}\n{new string('-', 30)}");
            Console.WriteLine($"Result of First = {list.First(predicate)}\n{new string('-', 30)}");
            Console.WriteLine($"Result of FirstOrDefault = {list.FirstOrDefault(predicate)}\n{new string('-', 30)}");
            Console.WriteLine($"Result of Last = {list.Last(predicate)}\n{new string('-', 30)}");
            Console.WriteLine($"Result of LastOrDefault = {list.LastOrDefault(predicate)}\n{new string('-', 30)}");
            
            Console.ReadKey();
        }   
    }
}
