using Lesson4Project.Models;
using Lesson4Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Controllers
{
    public class HumanController : Controller
    {
        private  IHumanRepository humanRep { get; }
        private  ICountryRepository countryRep { get; }
        public HumanController(IHumanRepository _humanRep, ICountryRepository _countryRep)
        {
            humanRep = _humanRep;
            countryRep = _countryRep;
        }

        public ActionResult Index(int ?id)
        {
            IEnumerable<HumanIndexViewModel> humans;

            humans = from h in humanRep.GetAllHumans()
                     join c in countryRep.AllCountries() on h.CountryId equals c.Id
                     select new HumanIndexViewModel 
                     {
                        Id= h.Id,
                        FirstName=h.FirstName,
                        LastName=h.LastName,
                        Age=h.Age,
                        CountryId=h.CountryId,
                        Country =c.Name
                     };
            if (id != null && id > 0)
            {
                return View(humans.Where(x => x.Id == id));
            }
            return View(humans);
        }

        public IActionResult Country(string countryName)
        {
            ViewData["Humans"] = humanRep.GetHumansByCountry(countryName);
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            List<Country> countries = countryRep.AllCountries();
            ViewBag.CountryList = new SelectList(countries,"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Human h)
        {
            if(ModelState.IsValid)
            {
                humanRep.CreateHuman(h);
                humanRep.CommitChanges();
                return Redirect("~/Human/Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Human human = humanRep.GetHuman(id);
            List<Country> countries = countryRep.AllCountries();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name", human.CountryId);
            return View(human);
        }

        [HttpPost]
        public IActionResult Update(Human h)
        {
            if (ModelState.IsValid)
            {
                humanRep.ModifyHuman(h);
                humanRep.CommitChanges();
                return Redirect("~/Human/Index");
            }
            else
            {
                List<Country> countries = countryRep.AllCountries();
                ViewBag.CountryList = new SelectList(countries, "Id", "Name", h.CountryId);
                return View(h);
                // return Redirect("~/Human/Update/"+h.Id);
            }
        }
        [HttpGet]
        public IActionResult DeleteHuman(int id)
        {
            humanRep.KillHuman(id);
            humanRep.CommitChanges();
            return Redirect("~/Human/Index");
        }


    }
}
