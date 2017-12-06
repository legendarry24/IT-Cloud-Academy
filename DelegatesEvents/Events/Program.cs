using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Test()
        {
            Console.WriteLine("Found!");
        }

        static void Main(string[] args)
        {
            var manager = new FileManager();
            manager.FileFound += Test;
            manager.FileFound += () => Console.WriteLine(manager);
            manager.FileNotFound += () => Console.WriteLine("Not found");

            manager.Search(true);

            Console.ReadKey();
        }
    }
}
