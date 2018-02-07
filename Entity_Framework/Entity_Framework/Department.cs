﻿using System.Collections.Generic;

namespace Entity_Framework
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Phone> Things { get; set; }
    }
}
