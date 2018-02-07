using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Laptop> Laptops { get; set; }
	}
}
