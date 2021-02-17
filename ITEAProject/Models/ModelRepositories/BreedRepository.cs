using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models.ModelRepositories
{
    public class BreedRepository:IBreedRepository
    {
        private readonly IteaProjectDbContext _context;

        public BreedRepository(IteaProjectDbContext context)
        {
            _context = context;
        }
        public List<Breed> Breeds()
        {
            return _context.Breeds.ToList();
        }

        public void Create(Breed breed)
        {
            _context.Breeds.Add(breed);
            _context.SaveChanges();
        }

        public void Update(Breed _breed)
        {
            Breed breed = _context.Breeds.Where(b => b.Id == _breed.Id).First();
            if(breed!=null)
            {
                breed.BreedName = _breed.BreedName;
                breed.BreedDescription = _breed.BreedDescription;
                _context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            Breed deleteBreed = _context.Breeds.Where(br => br.Id == Id).First();

            if (deleteBreed != null)
            {
                _context.Breeds.Remove(deleteBreed);
                _context.SaveChanges();
            }
        }
    }
}
