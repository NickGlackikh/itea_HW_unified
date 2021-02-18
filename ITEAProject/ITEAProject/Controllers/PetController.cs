using ITEAProject.Models;
using ITEAProject.Models.ModelRepositories;
using ITEAProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Controllers
{
    public class PetController : Controller
    {
        private IPetRepository _petRepository;
        private IBranchRepository _branchRepository;
        private IBreedRepository _breedRepository;
        private IOwnerRepository _ownerRepository;

        public PetController(IPetRepository petRepository, IBreedRepository breedRepository, 
                             IBranchRepository branchRepository, IOwnerRepository ownerRepository)
        {
            _petRepository = petRepository;
            _breedRepository = breedRepository;
            _branchRepository = branchRepository;
            _ownerRepository = ownerRepository;
        }
        public IActionResult Index(int? Id)
        {
            IEnumerable<PetIndexViewModel> pets;
            if (Id > 0 || Id != null)
            {
                pets = _petRepository.Pets().Where(p => p.BranchId == Id);
            }
            else
            {
                pets = _petRepository.Pets();
            }

            return View(pets);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Breed> breeds = _breedRepository.Breeds();
            ViewBag.BreedsList = new SelectList(breeds, "Id", "BreedName");

            List<Branch> branches = _branchRepository.AllBranches();
            ViewBag.BranchList = new SelectList(branches, "Id", "Address");

            List<Owner> owners = _ownerRepository.AllOwners();
            ViewBag.OwnerList = new SelectList(owners, "Id", "OwnerName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            if(ModelState.IsValid)
            {
                _petRepository.NewPet(pet);
                return Redirect("~/Pet/Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Pet pet = _petRepository.AllPets().Where(p=>p.Id==Id).First();

            List<Breed> breeds = _breedRepository.Breeds();
            ViewBag.BreedsList = new SelectList(breeds, "Id", "BreedName", pet.BreedId);

            List<Branch> branches = _branchRepository.AllBranches();
            ViewBag.BranchList = new SelectList(branches, "Id", "Address", pet.BranchId);

            List<Owner> owners = _ownerRepository.AllOwners();

            owners.Add(new Owner { Id=0, OwnerName=""});
            ViewBag.OwnerList = new SelectList(owners, "Id", "OwnerName", pet.OwnerId==null?0:pet.OwnerId);

            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(Pet pet)
        {
            if(pet.OwnerId==0)
            {
                pet.OwnerId = null;
            }

            if(ModelState.IsValid)
            {
                _petRepository.EditPet(pet);
                return Redirect("~/Pet/Index");
            }
            return View(pet);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            _petRepository.DeletePet(Id);
            return Redirect("~/Pet/Index");
        }
    }
}
