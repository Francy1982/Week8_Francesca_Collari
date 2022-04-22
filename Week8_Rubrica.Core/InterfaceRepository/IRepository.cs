using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8_Rubrica.Core.InterfaceRepository
{
    public interface IRepository<T>
    {
        IList<T>? GetAll();
        T? Add(T item);
        bool Delete(T item);
        T? GetById(int id);
    }
}
