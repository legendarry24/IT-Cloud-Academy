using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Cellphones
{
    public class CellphonesRepository : ICellphonesRepository
    {
        public const string RepositoryFilePath = @"S:\C-17-03\msr^_^\IT Cloud Academy\IT-Cloud-Academy\IOTest\CellphonesData\cellphones.txt";

        /// <summary>
        /// Adds phones to the repository
        /// </summary>
        /// <param name="phone">Cellphone</param>
        public void Add(Cellphone phone)
        {
            if (phone == null)
                throw new ArgumentNullException(nameof(phone));

            var phoneString = JsonConvert.SerializeObject(phone);

            using (var streamWriter = new StreamWriter(RepositoryFilePath, true))
                streamWriter.WriteLine(phoneString);
        }

        public IEnumerable<Cellphone> GetAll()
        {
            var phones = File.ReadAllLines(RepositoryFilePath);
            return phones.Select(x => JsonConvert.DeserializeObject<Cellphone>(x));
        }

        public void Remove(int id)
        {
            var phones = GetAll();

            if (!phones.Any(x => x.Id == id))
                throw new ArgumentException($"Can not remove cellphone with id: {id}. Object is not exists in the repository");

            var phonesUpdated = GetAll().Where(x => x.Id != id);
            File.Open(RepositoryFilePath, FileMode.OpenOrCreate)
                .Close();

            foreach (var phone in phonesUpdated)
                Add(phone);
        }

        public void Print(IEnumerable<Cellphone> phones)
        {
            foreach (var phone in phones)
                Console.WriteLine(phone);
        }
    }
}
