using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Data_access
{
    class CellphonesRepository : ICellphonesRepository
    {
        private const string RepositoryFilePath = @"S:\C-17-03\msr^_^\IT Cloud Academy\IT-Cloud-Academy\Data access\CellphonesData\cellphones.txt";

        public void Add(Cellphone phone)
        {
            //Represents an object as a string 
            string phoneString = JsonConvert.SerializeObject(phone);
            //File.AppendAllLines(RepositoryFilePath, new [] { phoneString} );

            //new implementation
            // false by default, true => append, false => rewrite and save last line
            using (StreamWriter streamWriter = new StreamWriter(RepositoryFilePath, true))
                streamWriter.WriteLine(phoneString);
        }

        public IEnumerable<Cellphone> GetAll()
        {
            //for 1 object
            //string phoneString = File.ReadAllText(RepositoryFilePath);
            //var cellphone = JsonConvert.DeserializeObject<Cellphone>(phoneString);
            //return new[] { cellphone };

            //new implementation
            string[] phones = File.ReadAllLines(RepositoryFilePath);
            return phones.Select(JsonConvert.DeserializeObject<Cellphone>);
            //the same
            //return phones.Select(x => JsonConvert.DeserializeObject<Cellphone>(x));
        }

        //public void Remove(int id)
        //{
        //    var phones = GetAll().Where(x => x.Id != id);
        //    //clear file
        //    File.Open(RepositoryFilePath, FileMode.Truncate)
        //        .Close();
        //    //and rewrite
        //    foreach (var phone in phones)
        //        Add(phone);
        //}

        //public void Print(IEnumerable<Cellphone> phones)
        //{
        //    foreach (var phone in phones)
        //        Console.WriteLine(phone);
        //}
    }
}