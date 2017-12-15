using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Control_2
{
    class Movie: BaseFile, IFile
    {
        public string Resolution { get; set; }

        public string Length { get; set; }

        public override string ToString()
        {
            return $"Movies:\n\t{base.ToString()}" + $"GB\n\t\tResolution: {Resolution}\n\t\tLength: {Length}";
        }
    }
}
