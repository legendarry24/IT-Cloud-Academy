using System;
using System.Runtime.Serialization;

namespace Data_access
{
    [Serializable]
    class Cellphone : ISerializable
    {
        
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public decimal Price { get; set; }

        //Serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Factory", Manufacturer);
        }

        //Deserialization
        public Cellphone(SerializationInfo info, StreamingContext context)
        {
            Manufacturer = info.GetString("Factory");
        }

        public Cellphone()
        {
                
        }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}\nModel: {Model}\nPrice: {Price}";
        }
    }
}
