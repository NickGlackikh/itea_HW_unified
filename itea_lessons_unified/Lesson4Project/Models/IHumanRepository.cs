using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Models
{
    public class IHumanRepository : IRepository
    {
        private InfestationDbContext dbContext;

        public IHumanRepository(InfestationDbContext _context)
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
            if(hum!=null)
            {
                dbContext.Humans.Remove(hum);
            }
            
        }

        public void ModifyHuman(Human human)
        {
            Human hum = dbContext.Humans.Where(h => h.Id == human.Id).First();
            if(hum !=null)
            {
                hum.FirstName = human.FirstName;
                hum.LastName = human.LastName;
                hum.Age = human.Age;
                hum.CountryId = human.CountryId;
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
                    join c in dbContext.Countries on h.CountryId equals c.Id
                    where c.Name == country
                    select h).ToList();
        }
    }
}
