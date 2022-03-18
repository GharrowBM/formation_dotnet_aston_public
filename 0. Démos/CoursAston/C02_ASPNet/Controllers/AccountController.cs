using C02_ASPNet.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace C02_ASPNet.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(CredentialVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            if (vm.UserName == "admin" && vm.Password == "admin")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@example.com"),
                    new Claim("Administrator", "true")
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, "AuthCookie");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    IsPersistent = vm.RememberMe
                };

                await HttpContext.SignInAsync("AuthCookie", claimsPrincipal, properties);

            }

            if (vm.UserName == "user" && vm.Password == "password")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, "user"),
                    new Claim(ClaimTypes.Email, "user@example.com"),
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, "AuthCookie");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    IsPersistent = vm.RememberMe
                };

                await HttpContext.SignInAsync("AuthCookie", claimsPrincipal, properties);

            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("AuthCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}
