using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access
{
    interface ICellphonesRepository
    {
        void Add(Cellphone phone);
        void Remove(int id);
        IEnumerable<Cellphone> GetAll();
    }
}
