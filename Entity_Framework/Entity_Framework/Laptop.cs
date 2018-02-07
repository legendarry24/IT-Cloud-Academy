using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Entity_Framework
{
	public class Laptop
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public string Manufacturer { get; set; }

		public ICollection<Person> Users { get; set; }
	}
}
