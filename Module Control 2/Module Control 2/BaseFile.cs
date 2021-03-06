﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Control_2
{
    abstract class BaseFile: IFile
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public override string ToString()
        {
            return $"{Name}\n\t\tExtension: {Extension}\n\t\tSize: {Size}";
        }
    }
}
