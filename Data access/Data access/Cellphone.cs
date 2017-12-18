using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access
{
    [Serializable]
    class Cellphone
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}\nModel: {Model}\nPrice: {Price}";
        }
    }
}
