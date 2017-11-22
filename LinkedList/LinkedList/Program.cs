using System;
using System.Collections.Generic;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List(1);
            list.Add(2);
            list.Add(5);
            list.Add(7);
            list.Print();
            Console.WriteLine(list[2].Value);
            Console.WriteLine(list[3].Value);
            Console.WriteLine(list[1].Value);
            Console.WriteLine(new string('*', 10));
            list.AddToBegin(10);
            list.Print();
            Console.WriteLine(list[0].Value);
            Console.WriteLine(list[4].Value);
            list.Remove(10);
            list.Remove(2);
            list.Print();
            Console.WriteLine($"Count = {list.Count}");
            Console.ReadKey();
        }
    }
}
