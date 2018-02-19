using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicShop.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
    }
}