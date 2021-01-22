using Lesson4Project.Models;
using Lesson4Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<CustomUser> userManager;
        private SignInManager<CustomUser> signInManager;
        public AccountController(UserManager<CustomUser> _userManager, SignInManager<CustomUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(AccountRegisterViewModel m)
        {

            if (ModelState.IsValid)
            {
                var user = new CustomUser() { FirstName = m.FirstName, LastName = m.LastName, UserName = m.UserName, Email = m.Email };
                var createTask = userManager.CreateAsync(user, m.Password);

                if (createTask.Result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in createTask.Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel m, string returnurl)
        {
            if (ModelState.IsValid)
            {
                var signInTask = await signInManager.PasswordSignInAsync(m.Email, m.Password,m.RememberMe, false);
                if (signInTask.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnurl))
                    {
                        return Redirect(returnurl);
                    }
                      return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect username or password");

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
