using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models.ModelRepositories
{
    public interface IBreedRepository
    {
        public List<Breed> Breeds();
        public void Create(Breed breed);

        public void Update(Breed breed);
        public void Delete(int Id);
    }
}
