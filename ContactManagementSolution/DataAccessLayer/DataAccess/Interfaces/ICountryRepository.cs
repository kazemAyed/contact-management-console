using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.DataAccess.Interfaces
{
    public interface ICountryRepository : IRepository<DtoCountry>
    {
    }

}
