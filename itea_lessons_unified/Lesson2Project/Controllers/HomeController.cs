using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2Project.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            ViewData["indexPhrase"] = "Hello, this is Home/Index method";
            return View();
        }
    }
}
