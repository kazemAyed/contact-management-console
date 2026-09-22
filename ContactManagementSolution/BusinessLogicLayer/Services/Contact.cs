using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess;

namespace BusinessLogicLayer.Services
{
    public class Contact : IContact
    {

        private static ContactRepository _DAContact = new ContactRepository();

        public int Add(DtoContact entity)
        {

            DataAccessLayer.Entities.DtoContact _entity = 
                new DataAccessLayer.Entities.DtoContact()
                {
                    ContactID = entity.ContactID,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Phone = entity.Phone,
                    Address = entity.Address,
                    Email = entity.Email,
                    CountryID = entity.CountryID
                };

            return _DAContact.Add(_entity);

        }

        public bool Delete(int id)
        {
            return _DAContact.Delete(id);
        }

        public IEnumerable<DtoContact> GetAll()
        {

            IEnumerable<DataAccessLayer.Entities.DtoContact> _All = _DAContact.GetAll();

            List<BusinessLogicLayer.DTOs.DtoContact> All = new List<DtoContact>();

            foreach (var entity in _All)
            {
                BusinessLogicLayer.DTOs.DtoContact con = 
                    new BusinessLogicLayer.DTOs.DtoContact()
                    {
                        ContactID = entity.ContactID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Phone = entity.Phone,
                        Address = entity.Address,
                        Email = entity.Email,
                        CountryID = entity.CountryID
                    };

                All.Add(con);

            }

            return All;

        }

        public DtoContact GetById(int id)
        {

            DataAccessLayer.Entities.DtoContact _entity = 
                _DAContact.GetById(id);

            if (_entity is null) return null;

            BusinessLogicLayer.DTOs.DtoContact entity = 
                new BusinessLogicLayer.DTOs.DtoContact()
                {
                    ContactID = _entity.ContactID,
                    FirstName = _entity.FirstName,
                    LastName = _entity.LastName,
                    Phone = _entity.Phone,
                    Address = _entity.Address,
                    Email = _entity.Email,
                    CountryID = _entity.CountryID
                };

            return entity;

        }

        public bool Update(DtoContact entity)
        {

            DataAccessLayer.Entities.DtoContact _entity = 
                new DataAccessLayer.Entities.DtoContact()
                {
                    ContactID = entity.ContactID,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Phone = entity.Phone,
                    Address = entity.Address,
                    Email = entity.Email,
                    CountryID = entity.CountryID
                };

            return _DAContact.Update(_entity);

        }
    }
}
