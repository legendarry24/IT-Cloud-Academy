using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen
{
    abstract class BasePenRepository
    {
        public abstract Pen Get(int id);

        public abstract void Add(Pen pen);
    }
}
