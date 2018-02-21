﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [UIHint("EmailAddress")]
        public string Email { get; set; }
    }
}