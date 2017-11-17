using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    interface IPencilsRepository
    {
        void Add(Pencil pencil);
        Pencil Get(int id);
        Pencil this[int index] { get; set; }
    }
}
