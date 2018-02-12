using System.Collections.Generic;

namespace Entity_Framework
{
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }

	    //many-to-many relationship 
        public ICollection<Laptop> Laptops { get; set; }
	}
}
