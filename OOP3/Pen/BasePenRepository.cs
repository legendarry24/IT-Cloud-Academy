using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen
{
    abstract class BasePenRepository : IPenRepository
    {
        public abstract int Count { get; }

        public abstract Pen this[int index] { get; set; }

        public abstract Pen Get(int id);

        public abstract void Add(Pen pen);

        public abstract void Delete(int index);
    }
}
