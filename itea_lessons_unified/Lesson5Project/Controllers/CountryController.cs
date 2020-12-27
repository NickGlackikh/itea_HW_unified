using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson5Project.Models;
using Lesson5Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lesson5Project.Controllers
{
    public class CountryController:Controller
    {
        private ICountryRepository countryrep { get; }
        public CountryController(IHumanRepository _humanrep, ICountryRepository _countryrep)
        {
            countryrep = _countryrep;
        }

        [Route("Country")]
        [Route("Country/Index")]
        public IActionResult Index()
        {
            return View(countryrep.AllCountries().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateCountry(Country _country)
        {
            countryrep.NewCountry(_country);
            countryrep.CommitChanges();
            return Redirect("~/Country");
        }

        public IActionResult Edit(int id)
        {
            Country country = countryrep.AllCountries().Where(c=>c.Id==id).First();
            return View(country);
        }

        public IActionResult UpdateCountry(Country _country)
        {
            countryrep.EditCountry(_country);
            countryrep.CommitChanges();
            return Redirect("~/Country");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            countryrep.DeleteCountry(id);
            countryrep.CommitChanges();
            return Redirect("~/Country");
        }
    }
}
