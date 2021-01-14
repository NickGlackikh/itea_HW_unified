using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Models
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

        public void CreateCountry(Country c)
        {
            dbContext.Countries.Add(c);
            dbContext.SaveChanges();
        }
    }
}
