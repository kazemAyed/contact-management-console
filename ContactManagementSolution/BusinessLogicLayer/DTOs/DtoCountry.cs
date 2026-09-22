using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class DtoCountry
    {
        public int CountryID { get; private set; }
        public string CountryName { get; set; } = null;
    }
}
