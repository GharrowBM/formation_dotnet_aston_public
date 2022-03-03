using C02_ASPNet.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace C02_ASPNet.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet] // Ici, notre GET ne nous renvoie que le formulaire de connexion
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost] // Ici, c'est la réelle méthode de connexion, qui doit être asynchrone car notre connexion dans l'HttpContext est une méthode asynchrone
        public async Task<IActionResult> Login(CredentialVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            if (vm.UserName == "admin" && vm.Password == "admin") // Idéalement, ces vérifications se feraient en BdD
            {
                List<Claim> claims = new List<Claim>() // Idéalement, cette liste serait récupérée par un JOIN en SQL dans la BdD
                {
                    // Les Claims sont en réalité un peu comme les lignes d'une carte d'identité

                    new Claim(ClaimTypes.Name, "admin"), // Le nom
                    new Claim(ClaimTypes.Email, "admin@example.com"), // Le mail
                    new Claim("Administrator", "true") // Le statut ( il est administrateur )
                };

                // On construit l'identité à partie des informations et en respectant le shéma demandé
                ClaimsIdentity identity = new ClaimsIdentity(claims, "AuthCookie");

                // On ajout cette identité en temps qu'identité principale
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                // ON ajoute des propriétés à l'authentification
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    IsPersistent = vm.RememberMe
                };

                // On se logue enfin, en spécifiant le shéma, l'identité principale et les propriétés de connexion
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

            // On redirige vers la page d'accueil
            return RedirectToAction("Index", "Home");
        }

        [HttpPatch] // Ici, on se déconnexte à partie du formulaire de déconnexion
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("AuthCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}
