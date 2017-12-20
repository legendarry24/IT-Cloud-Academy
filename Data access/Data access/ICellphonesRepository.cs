using System.Collections.Generic;

namespace Data_access
{
    interface ICellphonesRepository
    {
        void Add(Cellphone phone);
        //void Remove(int id);
        IEnumerable<Cellphone> GetAll();
    }
}
