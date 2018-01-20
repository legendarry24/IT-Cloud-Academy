using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.IO;
using 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access
{
    class Test
    {
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        public DateTime Date { get; set; }
    }

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

            #region CellphonesRepository
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
           // repository.Print(phones);

            //repository.Remove(0);
            phones = repository.GetAll();
            Console.WriteLine("\nAfter remove id = 0:");
            //repository.Print(phones); 
            #endregion

            IFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream stream = new FileStream("Test.data", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(stream, cellphone);
            }

            using (FileStream stream = new FileStream("Test.data", FileMode.OpenOrCreate))
            {
                var result = (Cellphone)binaryFormatter.Deserialize(stream);
            }

            JsonSerializer serializer = new JsonSerializer();

            //using (StringWriter writer = new StringWriter())
            //{
            //    serializer.Serialize(writer, cellphone);
            //    var result = writer.ToString();
            //}
            
            
            var format = System.Globalization.CultureInfo.CreateSpecificCulture("fr-CA");
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString());

            decimal val = 24.32m;
            Console.OutputEncoding = Encoding.Unicode;
            //Console.WriteLine(val.ToString("C1", );

            Console.WriteLine();


            //watch lecture
            Console.ReadKey();
        }
    }
}
