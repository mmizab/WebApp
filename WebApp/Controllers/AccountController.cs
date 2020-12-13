using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(WebAppContext context) : base(context)
        {

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            var user = _context.User.FirstOrDefault(o => o.Email == userName && o.Password == password);
            if (user == null)
            {
                return View();
            }

            //Create the identity for the user
            ClaimsIdentity identity = null;
            identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);


            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddHours(8), IsPersistent = false, AllowRefresh = true });

            return RedirectToAction("Index", "Admin");
        }


        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}