using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Cellphones;

namespace UnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Cellphone obj = new Cellphone();
            obj.Id = 1;
            obj.Manufacturer = "Apple";
            obj.Model = "X";
            obj.Price = 1400;

            var phone = new Cellphone
            {
                Id = 2,
                Manufacturer = "Meizu",
                Model = "M5",
                Price = 1000
            };

            IFormatter binaryFormatter = new BinaryFormatter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cellphone));

            Stream stream = new FileStream(
                @"D:\Downloads\C#\IT Cloud Academy\IT-Cloud-Academy-master\UnitTests\CellphonesData\MyFile.bin", 
                FileMode.Create, 
                FileAccess.Write, 
                FileShare.None);
            FileStream fileStream = new FileStream(
                @"D:\Downloads\C#\IT Cloud Academy\IT-Cloud-Academy-master\UnitTests\CellphonesData\MyXMLFile.xml", 
                FileMode.Create, 
                FileAccess.ReadWrite, 
                FileShare.None);

            binaryFormatter.Serialize(stream, obj);
            xmlSerializer.Serialize(fileStream, phone);
            stream.Close();
            fileStream.Close();

            ICellphonesRepository repository = new CellphonesRepository();
            repository.Add(obj);
            repository.Add(phone);

            //repository.Remove(1);

            foreach (var cellphone in repository.GetAll())
            {
                Console.WriteLine(cellphone);
            }

            Console.ReadKey();
        }
    }
}
