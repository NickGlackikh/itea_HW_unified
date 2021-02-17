using ITEAProject.Models;
using ITEAProject.Models.ModelRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Controllers
{
    public class BreedController : Controller
    {
        private readonly IBreedRepository _breedRepository;

        public BreedController(IBreedRepository breedRepository)
        {
            _breedRepository = breedRepository;
        }
        public ActionResult Index()
        {
            List<Breed> breeds = _breedRepository.Breeds();
            return View(breeds);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Breed breed)
        {
            _breedRepository.Create(breed);
            return Redirect("~/Breed/Index");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            Breed breed = _breedRepository.Breeds().Where(b => b.Id == Id).First();
            return View(breed);
        }

        [HttpPost]
        public ActionResult Update(Breed breed)
        {
            if (ModelState.IsValid)
            {
                _breedRepository.Update(breed);
                return Redirect("~/Breed/Index");
            }
            return View(breed);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            _breedRepository.Delete(Id);
            return Redirect("~/Breed/Index");
        }
    }
}
