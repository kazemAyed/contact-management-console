using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        int Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Update(T entity);
        bool Delete(int id);
    }

}
