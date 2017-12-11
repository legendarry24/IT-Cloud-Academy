using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access
{
    class CellphonesRepository : ICellphonesRepository
    {
        private const string RepositoryFilePath = @"S:\C-17-03\msr^_^\IT Cloud Academy\IT-Cloud-Academy\Data access\CellphonesData\cellphones.txt";

        public void Add(Cellphone phone)
        {
            //Представляет обьект в виде строки
            string phoneString = JsonConvert.SerializeObject(phone);
            //File.AppendAllLines(RepositoryFilePath, new[] { phoneString });
            //new implementation
            using (StreamWriter streamWriter = new StreamWriter(RepositoryFilePath, true))
                streamWriter.WriteLine(phoneString);
        }

        public IEnumerable<Cellphone> GetAll()
        {
            string[] phones = File.ReadAllLines(RepositoryFilePath);
            //var cellphones = JsonConvert.DeserializeObject<Cellphone>(phoneString);
            //return new[] { cellphones };
            //new implementation
            return phones.Select(x => JsonConvert.DeserializeObject<Cellphone>(x));
        }

        public void Remove(int id)
        {
            var phones = GetAll().Where(x => x.Id != id);
            File.Open(RepositoryFilePath, FileMode.Truncate)
                .Close();

            foreach (var phone in phones)
            {
                Add(phone);
            }
        }
    }
}
