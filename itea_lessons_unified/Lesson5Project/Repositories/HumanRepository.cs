using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson5Project.Models;

namespace Lesson5Project.Repositories
{
    public class HumanRepository : IHumanRepository
    {
        private InfestationDbContext dbContext;

        public HumanRepository(InfestationDbContext _context)
        {
            dbContext = _context;
        }

        public List<Human> GetAllHumans()
        {
            return dbContext.Humans.ToList();
        }

        public Human GetHuman(int id)
        {
            return dbContext.Humans.Find(id);
        }

        public void CreateHuman(Human h)
        {
            dbContext.Humans.Add(h);
        }

        public void KillHuman(int id)
        {
            Human hum = dbContext.Humans.Where(h => h.Id == id).First();
            if (hum != null)
            {
                dbContext.Humans.Remove(hum);
            }

        }

        public void ModifyHuman(Human human)
        {
            Human hum = dbContext.Humans.Where(h => h.Id == human.Id).First();
            if (hum != null)
            {
                hum.FirstName = human.FirstName;
                hum.LastName = human.LastName;
                hum.Age = human.Age;
                hum.DistrictId = human.DistrictId;
                hum.Gender = human.Gender;
                hum.IsSick = human.IsSick;
            }
        }

        public void CommitChanges()
        {
            dbContext.SaveChanges();
        }

        public List<Human> GetHumansByCountry(string country)
        {
            return (from h in dbContext.Humans
                    join d in dbContext.Districts on h.DistrictId equals d.Id
                    join c in dbContext.Countries on d.CountryId equals c.Id
                    where c.Name == country
                    select h).ToList();
        }

        public List<District> GetDistricts()
        {
            return dbContext.Districts.ToList();
        }

    }
}
