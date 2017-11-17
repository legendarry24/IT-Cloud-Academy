using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    class Program
    {
        private static IPencilsRepository _pencilsRepository;

        static void Main(string[] args)
        {
            var pen = new Pen("BIC");
            pen.Manufacturer = "MaxRighter";
            //Console.WriteLine(pen.Manufacturer);

            var pencil = new Pencil
            {
                Id = 0,
                Price = 24,
                Brand = "Marc",
                Size = 25
            };

            //_pencilsRepository = new PencilsFileRepository();
            _pencilsRepository = new PencilsRepository(24);                      
            _pencilsRepository[1] = new Pencil
            {
                Id = 1,
                Brand = "Castel",
                Price = 25
            };

            _pencilsRepository.Add(pencil);
            Console.WriteLine(_pencilsRepository[0].ToString());
            var repo = (BasePencilRepository)_pencilsRepository;
            repo.Print(_pencilsRepository[1]);
            


            Console.ReadKey();
        }
    }
}
