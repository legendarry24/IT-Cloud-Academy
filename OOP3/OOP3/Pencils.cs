using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    class Pencils
    {
        private Pencil[] _pencils;

        public Pencils(int size)
        {
            _pencils = new Pencil[size];
        }

        public Pencil this[int index]
        {
           get { return _pencils[index]; }
           set { _pencils[index] = value; }
        }
    }
}
