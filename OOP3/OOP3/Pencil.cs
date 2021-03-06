﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    class Pencil
    {
        public int Id { get; set; }

        public int Size { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}\n{nameof(Brand)}: {Brand}\n{nameof(Price)}: {Price}";
        }
    }
}
