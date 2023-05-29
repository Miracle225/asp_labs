using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Furniture_Shop.ViewModels;
using Furniture_Shop.ViewModels.RegisterModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Furniture_Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public ViewResult Login(string returnUrl = "")
        {
            var model = new LoginModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await
                    _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, loginModel.RememberMe,
                        false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginModel.ReturnUrl) || !Url.IsLocalUrl(loginModel.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Console.WriteLine($"Redirecting to {loginModel.ReturnUrl}");
                        return RedirectToPage(loginModel.ReturnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ToString());
                }
            }

            return View(loginModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Register(string returnUrl = "")
        {
            var model = new RegisterModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid && registerModel.Password == registerModel.RepeatPassword)
            {
                var user = new IdentityUser { UserName = registerModel.Username };
                var result = await _userManager.CreateAsync(user,
                    registerModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, registerModel.RememberMe);
                    if (string.IsNullOrEmpty(registerModel.ReturnUrl) || !Url.IsLocalUrl(registerModel.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(registerModel.ReturnUrl);
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(registerModel);
        }
    }
}