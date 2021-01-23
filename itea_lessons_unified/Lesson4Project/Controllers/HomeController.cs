using Lesson4Project.Models;
using Lesson4Project.Services;
using Lesson4Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Controllers
{
    public class HomeController : Controller
    {
        private IHumanRepository humanRep { get; }
        private ICountryRepository countryRep { get; }
        private ServiceFactory factory { get; }
        
        public object HomaInfoViewModel { get; private set; }

        public HomeController(IHumanRepository _humanRep, ICountryRepository _countryRep,
                              ServiceFactory _factory)
        {
            humanRep = _humanRep;
            countryRep = _countryRep;
            factory = _factory;
        }

        public IActionResult Info()
        {
            IEnumerable<Human> humans = humanRep.GetAllHumans();
            IEnumerable<Country> countries = countryRep.AllCountries();
            HomeInfoViewModel model = new HomeInfoViewModel(){ Humans= humans, Countries= countries };
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SendMessage(HomeSendViewModel m)
        {
            factory.getSenderType(m.MessageType).SendMessage(m.AddrTo, m.Text);
            return Redirect("~/Home/Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
