using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICountry : ICrud<DataAccessLayer.Entities.DtoCountry>
    {
    }
}
