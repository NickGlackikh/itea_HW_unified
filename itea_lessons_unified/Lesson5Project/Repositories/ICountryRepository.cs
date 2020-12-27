using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson5Project.Models;

namespace Lesson5Project.Repositories
{
    public interface ICountryRepository
    {
        List<Country> AllCountries();
        int CountryById(int humId);
        void NewCountry(Country c);
        void EditCountry(Country c);
        void DeleteCountry(int id);
        void CommitChanges();
    }
}
