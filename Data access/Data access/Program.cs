using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
                Manufacturer = "Apple",
                Model = "X",
                Price = 1456.98m
            };

            var cellphone1 = new Cellphone
            {
                Manufacturer = "Samsung",
                Model = "Galaxy S8",
                Price = 1356.99m
            };

            repository.Add(cellphone);
            repository.Add(cellphone1);
            repository.Remove(0);
            var phones = repository.GetAll();

            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }

            IFormatter binaryFormatter = new BinaryFormatter();
            //watch lecture

            Console.ReadKey();
        }
    }
}
