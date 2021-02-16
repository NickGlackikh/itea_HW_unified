using Lesson4Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Controllers
{
    [Produces("application/json")]
     public class RestController : Controller
    {
        private ICountryRepository countryrep { get; }
        public RestController(IHumanRepository _humanrep, ICountryRepository _countryrep)
        {
            countryrep = _countryrep;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return Json(countryrep.AllCountries().ToList());
        }
    }
}
