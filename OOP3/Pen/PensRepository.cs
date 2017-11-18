using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen
{
    class PensRepository : BasePenRepository, IPenRepository
    {
        private Pen[] _pens;
        private int _lastIndex;

        public PensRepository(int size)
        {
            _pens = new Pen[size];
        }

        public Pen this[int index]
        {
            get
            {
                if (index >= 0 && index < _pens.Length)
                {
                    return _pens[index];
                }
                else
                {
                    return null;
                }
            }
            set { _pens[index] = value; }
        }

        public int Count => _pens.Length;

        public override void Add(Pen pen)
        {
            _pens[_lastIndex++] = pen;
        }

        public void Delete(int index)
        {
            for (int i = 0; i < Count; i++)
            {
                if (i < index && i > index)
                {
                    _pens[i] = _pens[i];
                }               
            }
        }

        public override Pen Get(int id)
        {
            for (int i = 0; i < Count; i++)
            {
                if (true)
                {

                }
            }
        }
    }
}
