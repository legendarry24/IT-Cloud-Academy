using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    class PencilsRepository : BasePencilRepository, IPencilsRepository
    {
        private Pencil[] _pencils;
        private int _lastIndex;

        public PencilsRepository(int size)
            :base(size)
        {
            _pencils = new Pencil[size];
        }

        public Pencil this[int index]
        {
           get { return _pencils[index]; }
           set { _pencils[index] = value; }
        }

        public override void Add(Pencil pencil)
        {
            _pencils[_lastIndex++] = pencil;
        }

        public override Pencil Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
