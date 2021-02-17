using ITEAProject.Services.Repositories;
using ITEAProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private readonly IMessageSender _sender;

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager, IMessageSender sender)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            _sender = sender;
        }

        [HttpGet]
        [AllowAnonymous]
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
                var user = new IdentityUser { UserName = m.UserName, Email = m.Email };
                var createTask = userManager.CreateAsync(user, m.Password);

                if (createTask.Result.Succeeded)
                {
                    _sender.SendMessage(m.Email);
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
                var signInTask = await signInManager.PasswordSignInAsync(m.UserName, m.Password, m.RememberMe, false);
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
