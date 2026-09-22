using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    internal class Countrycs : ICountry
    {
        public int Add(DataAccessLayer.Entities.DtoCountry entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataAccessLayer.Entities.DtoCountry> GetAll()
        {
            throw new NotImplementedException();
        }

        public DataAccessLayer.Entities.DtoCountry GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(DataAccessLayer.Entities.DtoCountry entity)
        {
            throw new NotImplementedException();
        }
    }
}
