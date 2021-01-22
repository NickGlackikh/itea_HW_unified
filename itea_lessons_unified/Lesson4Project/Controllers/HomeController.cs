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

        private IMessageSender sender { get; }
        public object HomaInfoViewModel { get; private set; }

        public HomeController(IHumanRepository _humanRep, ICountryRepository _countryRep, IMessageSender _sender)
        {
            humanRep = _humanRep;
            countryRep = _countryRep;
            sender = _sender;
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
            //sender.SendMessage();
            return View();
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
