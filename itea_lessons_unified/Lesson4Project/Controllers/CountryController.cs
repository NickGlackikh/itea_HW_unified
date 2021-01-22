using Lesson4Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Controllers
{
    public class CountryController : Controller
    {
        private ICountryRepository countryRep { get; }
        public CountryController(ICountryRepository _countryRep)
        {
            countryRep = _countryRep;
        }

        public ActionResult Index(int? id)
        {
            if (id != null && id > 0)
            {
                return View(countryRep.AllCountries().Where(x => x.Id == id).ToList());
            }
            return View(countryRep.AllCountries());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Country c)
        {
            if(ModelState.IsValid)
            {
                countryRep.CreateCountry(c);
                return Redirect("~/Country/Index");
            }
            return View();
        }
    }
}
