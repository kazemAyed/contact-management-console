using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess.Interfaces
{
    public interface IContactRepository:IRepository<DtoContact>
    {
    }
}
