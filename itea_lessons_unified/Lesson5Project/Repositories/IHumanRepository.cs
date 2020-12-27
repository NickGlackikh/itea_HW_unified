using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson5Project.Models;

namespace Lesson5Project.Repositories
{
    public interface IHumanRepository
    {
        List<Human> GetAllHumans();
        List<Human> GetHumansByCountry(string country);
        Human GetHuman(int id);
        void CreateHuman(Human h);
        void ModifyHuman(Human h);
        void KillHuman(int id);
        void CommitChanges();
        List<District> GetDistricts();
    }
}
