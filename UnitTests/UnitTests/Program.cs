using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Cellphones;

namespace IOTest
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

            ICellphonesRepository repository = new CellphonesRepository();
            repository.Add(obj);
            repository.Add(phone);

            //repository.Remove(1);
            IFormatter binaryFormatter = new BinaryFormatter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cellphone));

            Stream stream = new FileStream(
                @"S:\C-17-03\msr^_^\IT Cloud Academy\IT-Cloud-Academy\IOTest\CellphonesData\MyFile.bin", 
                FileMode.Create, 
                FileAccess.Write, 
                FileShare.None);
            FileStream fileStream = new FileStream(
                @"S:\C-17-03\msr^_^\IT Cloud Academy\IT-Cloud-Academy\IOTest\CellphonesData\MyXMLFile.xml", 
                FileMode.Create, 
                FileAccess.Write, 
                FileShare.None);

            binaryFormatter.Serialize(stream, obj);
            xmlSerializer.Serialize(fileStream, obj);
            stream.Close();
            fileStream.Close();

            Console.ReadKey();
        }
    }
}
