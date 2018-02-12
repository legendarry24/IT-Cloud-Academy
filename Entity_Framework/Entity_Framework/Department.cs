using System.Collections.Generic;

namespace Entity_Framework
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //one-to-many relationship (the "one" side)
        public virtual ICollection<Phone> Things { get; set; } // virtual for lazy loading
    }
}
