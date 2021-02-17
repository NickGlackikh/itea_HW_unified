using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models.ModelRepositories
{
    public interface IOwnerRepository
    {
        public List<Owner> AllOwners();
        public void AddOwner(Owner owner);
        public void UpdateOwner(Owner owner);

        public void DeleteOwner(int Id);
    }
}
