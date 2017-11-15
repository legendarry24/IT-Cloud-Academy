using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    public class Pen
    {
        private int _x;
        private string _manufacturer;
        private decimal _price;

        public const int Size = 56;

        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (value != "Sample text")
                {
                    _manufacturer = value;
                }
            }
        }

        public string Color { get; private set; }

        public decimal Price => _price * 26.85m;

        public Pen(int x)
        {
            _x = x;
        }

        public Pen(string manufacturer)
        {
            _manufacturer = manufacturer;
        }
    }
}
