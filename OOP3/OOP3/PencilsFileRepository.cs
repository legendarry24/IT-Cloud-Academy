using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    class PencilsFileRepository : IPencilsRepository
    {
        public Pencil this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Pencil pencil)
        {
            throw new NotImplementedException();
        }

        public Pencil Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
