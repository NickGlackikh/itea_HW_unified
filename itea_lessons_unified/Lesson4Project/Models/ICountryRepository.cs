using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Models
{
   public interface ICountryRepository
    {
        List<Country> AllCountries();
        void CreateCountry(Country c);
    }
}
