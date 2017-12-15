using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access
{
    class Program
    {
        static void Main(string[] args)
        {
            //TextReader consoleStream = Console.In;
            //TextWriter consoleOut = Console.Out;
            //TextWriter consoleError = Console.Error;

            //string filePath = @"S:\C-17-03\msr^_^\IT Cloud Academy\IT-Cloud-Academy\Data access\file.txt";
            //string text = "Hello World!";
            //File.WriteAllLines(filePath, new[] { text });
            //var fileText = File.ReadAllText(filePath);
            //Console.WriteLine(fileText);
            #region using
            //using (FileStream fileStream = File.Create(@"S:\C-17-03\msr^_^\IT Cloud Academy\IT-Cloud-Academy\Data access\file.txt"))
            //{

            //}

            //the same 
            //FileStream fileStream;

            //try
            //{
            //    fileStream = File.Create(@"S:\C-17-03\msr^_^\IT Cloud Academy\IT-Cloud-Academy\Data access\file.txt");
            //}
            //finally
            //{
            //    fileStream.Dispose(); // Dispose invokes Close
            //}
            #endregion
            //FileAttributes attributes = File.GetAttributes(filePath);
            //Console.WriteLine(attributes);

            var repository = new CellphonesRepository();

            var cellphone = new Cellphone
            {
                Id = 0,
                Manufacturer = "Apple",
                Model = "X",
                Price = 1456.98m
            };
            repository.Add(cellphone);

            var cellphone1 = new Cellphone
            {
                Id = 1,
                Manufacturer = "Samsung",
                Model = "Galaxy S8",
                Price = 1356.99m
            };
            repository.Add(cellphone1);

            var phones = repository.GetAll();
            repository.Print(phones);

            repository.Remove(0);
            phones = repository.GetAll();
            Console.WriteLine("\nAfter remove id = 0:");
            repository.Print(phones);

            Console.ReadKey();
        }
    }
}
