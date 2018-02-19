﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicShop.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public int PhoneId { get; set; }
        public DateTime Date { get; set; }
    }
}