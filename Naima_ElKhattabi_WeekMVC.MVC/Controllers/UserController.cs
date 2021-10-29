using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Naima_ElKhattabi_WeekMVC.Core.BusinessLayer;
using Naima_ElKhattabi_WeekMVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IBusinessLayer BL; //per collegarsi alle logiche di business

        public UserController(IBusinessLayer bl)
        {
            BL = bl; 
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserViewModel
            {
                ReturnUrl = returnUrl
            });
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserViewModel utenteLoginViewModel)
        {
            if (utenteLoginViewModel == null)
            {
                return View();
            }

            var utente = BL.GetAccount(utenteLoginViewModel.Username);
            if (utente != null && ModelState.IsValid)
            {
                if (utente.Password == utenteLoginViewModel.Password)
                {
                    //l'utente è autenticato

                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utente.Name),
                        new Claim(ClaimTypes.Role, utente.Role.ToString())
                    };

                    var properties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1), // logout dopo un'ora di inattività
                        RedirectUri = utenteLoginViewModel.ReturnUrl
                    };
                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(utenteLoginViewModel.Password), "Password errata");
                    return View(utenteLoginViewModel);
                }
            }
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Forbidden() => View();
    }
}
