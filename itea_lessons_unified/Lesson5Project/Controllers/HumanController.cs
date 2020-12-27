using Lesson5Project.Models;
using Lesson5Project.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson5Project.Controllers
{
    public class HumanController : Controller
    {
        private IHumanRepository humanrep { get; }
        private ICountryRepository countryrep { get; }
        public HumanController(IHumanRepository _humanrep, ICountryRepository _countryrep)
        {
            humanrep = _humanrep;
            countryrep = _countryrep;
        }

        [Route("human")]
        [Route("human/{id}")]
        public ActionResult Index(int ?id)
        {
            return View(humanrep.GetAllHumans().Where(x=> x.Id==id||id==null||id==0).ToList());
        }
        [Route("human/country/{countryName:alpha:minlength(2)}")]
        public IActionResult Country(string countryName)
        {
            ViewData["Humans"] = humanrep.GetHumansByCountry(countryName);
            return View();
        }

        public IActionResult Create()
        {
            List<Country> countries = countryrep.AllCountries();
            List<District> districts = humanrep.GetDistricts();
            ViewBag.DistrictList = new SelectList(districts, "Id", "DistrictName");
            ViewBag.CountryList = new SelectList(countries,"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateHuman(Human h)
        {
            humanrep.CreateHuman(h);
            humanrep.CommitChanges();
            return Redirect("~/Human/Index");
        }

        public IActionResult Edit(int id)
        {
            Human human = humanrep.GetHuman(id);
            List<Country> countries = countryrep.AllCountries();
            List<District> districts = humanrep.GetDistricts().Where(d=>d.CountryId== countryrep.CountryById(human.Id)).ToList();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name", countryrep.CountryById(human.Id));
            ViewBag.DistrictList = new SelectList(districts, "Id", "DistrictName",human.DistrictId);
            
            return View(human);
        }

        [HttpPost]
        public IActionResult UpdateHuman(Human h)
        {
            humanrep.ModifyHuman(h);
            humanrep.CommitChanges();
            return Redirect("~/Human/Index");
        }

        [HttpGet]
        public IActionResult DeleteHuman(int id)
        {
            humanrep.KillHuman(id);
            humanrep.CommitChanges();
            return Redirect("~/Human/Index");
        }
        [HttpGet]
        public JsonResult GetCountryDistricts(int _countryId)
        {
            List<District> dist = humanrep.GetDistricts().Where(x => x.CountryId == _countryId).ToList();
            return Json(humanrep.GetDistricts().Where(x => x.CountryId == _countryId).ToList());
        }

        [Route("human/districtpage/{id:int:min(1):maxlength(10)}")]
        public IActionResult DistrictName(int id)
        {
            List<Human> humans = humanrep.GetAllHumans().ToList();
            List<District> districts = humanrep.GetDistricts().ToList();

            ViewData["District"] = (from h in humans
                                    join d in districts on h.DistrictId equals d.Id
                                    where h.Id==id
                                    select d.DistrictName).First();
            return View();
        }
    }
}
