using System;

namespace Cellphones
{
    [Serializable]
    public class Cellphone
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
