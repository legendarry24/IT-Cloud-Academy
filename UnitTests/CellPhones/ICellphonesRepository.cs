using System.Collections.Generic;

namespace Cellphones
{
    public interface ICellphonesRepository
    {
        void Add(Cellphone phone);
        void Remove(int id);
        IEnumerable<Cellphone> GetAll();
    }
}
