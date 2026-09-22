using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        int Add(T entity);

        bool Update(T entity);

        bool Delete(int id);
    }
}
