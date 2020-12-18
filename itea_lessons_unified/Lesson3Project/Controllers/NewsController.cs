using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BasicInfo.Models;

namespace Lesson3Project.Controllers
{
    public class NewsController:Controller
    {
        public IActionResult Index()
        {
            ViewBag.Content = NewsBase.News;
            return View();
        }
    }
}
