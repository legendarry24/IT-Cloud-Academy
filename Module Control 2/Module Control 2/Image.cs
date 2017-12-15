using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Control_2
{
    class Image: BaseFile, IFile
    {
        public string Resolution { get; set; }

        public override string ToString()
        {
            return $"Images:\n\t{base.ToString()}" + $"MB\n\t\tResolution: {Resolution}";
        }
    }
}
