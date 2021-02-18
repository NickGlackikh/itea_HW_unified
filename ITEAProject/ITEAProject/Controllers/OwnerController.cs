using ITEAProject.Models;
using ITEAProject.Models.ModelRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Controllers
{
    public class OwnerController : Controller
    {
        private IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public IActionResult Index()
        {
            List<Owner> owners = _ownerRepository.AllOwners();
            return View(owners);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            if (ModelState.IsValid)
            {
                _ownerRepository.AddOwner(owner);
                return Redirect("~/Owner/Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Owner owner = _ownerRepository.AllOwners().Where(br => br.Id == Id).First();
            return View(owner);
        }

        [HttpPost]
        public ActionResult Update(Owner owner)
        {
            if(ModelState.IsValid)
            {
                _ownerRepository.UpdateOwner(owner);
                return Redirect("~/Owner/Index");
            }

            return View(owner);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            _ownerRepository.DeleteOwner(Id);
            return Redirect("~/Owner/Index");
        }
    }
}
