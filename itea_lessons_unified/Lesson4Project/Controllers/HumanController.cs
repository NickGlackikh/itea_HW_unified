using Lesson4Project.Models;
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
        private IHumanRepository rep { get; }
        private InfestationDbContext context { get; }
        public HumanController(IHumanRepository _rep, InfestationDbContext _context)
        {
            rep = _rep;
            context = _context;
        }

        public ActionResult Index()
        {
            return View(rep.GetAllHumans());
        }

        public ActionResult FindById(int id)
        {
            if(id==0)
            {
                return Redirect("~/Human/Index");
            }

            return View(rep.GetHuman(id));
        }

        public IActionResult Country(string countryName)
        {
            ViewData["Humans"] = rep.GetHumansByCountry(countryName);
            return View();
        }

        public IActionResult Create()
        {
            List<Country> countries = context.Countries.ToList();
            ViewBag.CountryList = new SelectList(countries,"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateHuman(Human h)
        {
            rep.CreateHuman(h);
            rep.CommitChanges();
            return Redirect("~/Human/Index");
        }

        public IActionResult Edit(int id)
        {
            Human human = rep.GetHuman(id);
            List<Country> countries = context.Countries.ToList();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name", human.CountryId);
            return View(human);
        }

        [HttpPost]
        public IActionResult UpdateHuman(Human h)
        {
            rep.ModifyHuman(h);
            rep.CommitChanges();
            return Redirect("~/Human/Index");
        }
        [HttpGet]
        public IActionResult DeleteHuman(int id)
        {
            rep.KillHuman(id);
            rep.CommitChanges();
            return Redirect("~/Human/Index");
        }


    }
}
