using ITEAProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models.ModelRepositories
{
    public interface IPetRepository
    {
        List<PetIndexViewModel> Pets();
        List<Pet> AllPets();
        void NewPet(Pet pet);
        void EditPet(Pet pet);
        void DeletePet(int Id);
    }
}
