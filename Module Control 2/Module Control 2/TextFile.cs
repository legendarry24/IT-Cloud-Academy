using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Control_2
{
    class TextFile: BaseFile, IFile
    {
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Text files:\n\t{base.ToString()}" + $"B\n\t\tContent: {Content}";
        }
    }
}
