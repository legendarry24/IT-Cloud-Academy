using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen
{
    interface IPenRepository
    {
        void Delete(int index);
        int Count { get; }
        Pen this[int index] { get; set; }
    }
}
