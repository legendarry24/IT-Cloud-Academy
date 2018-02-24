using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ElectronicShop.Models
{
    public class Phone
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Manufacturer) + "*")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Please, select Name")]
        [Display(Name = "Name")]
        public string Model { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}