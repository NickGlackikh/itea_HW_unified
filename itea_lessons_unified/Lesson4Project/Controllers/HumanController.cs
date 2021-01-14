using Lesson4Project.Models;
using Lesson4Project.ViewModels;
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

        public IActionResult Create()
        {
            List<Country> countries = countryRep.AllCountries();
            ViewBag.CountryList = new SelectList(countries,"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Human h)
        {
            humanRep.CreateHuman(h);
            humanRep.CommitChanges();
            return Redirect("~/Human/Index");
        }

        public IActionResult Edit(int id)
        {
            Human human = humanRep.GetHuman(id);
            List<Country> countries = countryRep.AllCountries();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name", human.CountryId);
            return View(human);
        }

        [HttpPost]
        public IActionResult UpdateHuman(Human h)
        {
            humanRep.ModifyHuman(h);
            humanRep.CommitChanges();
            return Redirect("~/Human/Index");
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
