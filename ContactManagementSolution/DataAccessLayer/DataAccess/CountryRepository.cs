using DataAccessLayer.DataAccess.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class CountryRepository : ICountryRepository
    {
        public int Add(DtoCountry entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DtoCountry> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoCountry GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(DtoCountry entity)
        {
            throw new NotImplementedException();
        }
    }
}
