using System;
using System.Collections.Generic;
using Lesson5Project.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson5Project.Repositories
{
    public class CountryRepository:ICountryRepository
    {
        private InfestationDbContext dbContext;

        public CountryRepository(InfestationDbContext _context)
        {
            dbContext = _context;
        }
        public List<Country> AllCountries()
        {
            return dbContext.Countries.ToList();
        }

        public int CountryById(int humanId)
        {
            int country = (from c in dbContext.Countries
                           join d in dbContext.Districts on c.Id equals d.CountryId
                           join h in dbContext.Humans on d.Id equals h.DistrictId
                           where h.Id == humanId
                           select c.Id).Single();

            return country;
        }

        public void NewCountry(Country c)
        {
            dbContext.Countries.Add(c);
        }

        public void EditCountry(Country _country)
        {
            Country country = dbContext.Countries.Where(x => x.Id == _country.Id).First();
            if (country != null)
            {
                country.Name = _country.Name;
                country.Population = _country.Population;
                country.SickCount = _country.SickCount;
                country.DeadCount = _country.DeadCount;
                country.RecoveredCount = _country.RecoveredCount;
                country.Vaccine = _country.Vaccine;
            }
        }
        public void DeleteCountry(int id)
        {
            Country country = dbContext.Countries.Where(c => c.Id == id).First();
            if (country != null)
            {
                dbContext.Countries.Remove(country);
            }

        }

        public void CommitChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
