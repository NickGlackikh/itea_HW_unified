using ITEAProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models.ModelRepositories
{
    public class PetRepository:IPetRepository
    {
        private readonly IteaProjectDbContext _context;
        public PetRepository(IteaProjectDbContext context)
        {
            _context = context;
        }

        public List<Pet> AllPets()
        {
            List<Pet> resultList = _context.Pets.ToList();
            return resultList;
        }
        public List<PetIndexViewModel> Pets()
        {
            List<PetIndexViewModel> resultList = (from p in _context.Pets.DefaultIfEmpty()
                                                  join b in _context.Branches on p.BranchId equals b.Id
                                                  join o in _context.Owners on p.OwnerId equals o.Id into Owners
                                                  from m in Owners.DefaultIfEmpty()
                                                  join br in _context.Breeds on p.BreedId equals br.Id
                                                  select new PetIndexViewModel()
                                                  {
                                                      Id=p.Id,
                                                      Name = p.PetName,
                                                      Age = p.Age,
                                                      BreedId=p.BreedId,
                                                      BranchId = b.Id,
                                                      BreedName = br.BreedName,
                                                      OwnerId = m !=null ?m.Id:0 ,
                                                      OwnerName = m != null ? m.OwnerName:""
                                                  }).ToList();

            return resultList;
        }

        public void NewPet(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public void EditPet(Pet pet)
        {
            Pet petForEdit = _context.Pets.Where(p=>p.Id==pet.Id).First();

            if(petForEdit!=null)
            {
                petForEdit.PetName = pet.PetName;
                petForEdit.Age = pet.Age;
                petForEdit.BranchId = pet.BranchId;
                petForEdit.BreedId = pet.BreedId;
                petForEdit.Gender = pet.Gender;
                petForEdit.OwnerId = pet.OwnerId;

                _context.SaveChanges();
            }
        }

        public void DeletePet(int Id)
        {
            Pet deletePet = _context.Pets.Where(p => p.Id == Id).First();

            if (deletePet != null)
            {
                _context.Pets.Remove(deletePet);
                _context.SaveChanges();
            }
        }
    }
}
