using Lesson4Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Controllers
{
    public class AccountController:Controller
    {

        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel m)
        {

            
            if(ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = m.UserName, Email = m.Email };
                var createTask = userManager.CreateAsync(user, m.Password);

                if(createTask.Result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }

                foreach(var error in createTask.Result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View();
        }
    }
}
