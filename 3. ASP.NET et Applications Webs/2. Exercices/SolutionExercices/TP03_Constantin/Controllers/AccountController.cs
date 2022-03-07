using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bookstore.Controllers
{
    public class AccountController : Controller
    {
        DatabaseMock _db;
        public AccountController(DatabaseMock db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM log)
        {
            Users temp = _db.GetUsers().Find(x => x.Email == log.Email);
            if (temp == null || !ModelState.IsValid)
            {
                return View(log);
            }
            else
            {
                if (temp.Password == log.Password)
                {
                    _db.loggedUser = temp;
                    if (temp.Role == Users.RoleEnum.admin)
                    {
                        List<Claim> claims = new List<Claim>() 
                        {
                            new Claim(ClaimTypes.Name, temp.Name), 
                            new Claim(ClaimTypes.Email, temp.Email), 
                            new Claim("Administrator", "true")
                        };
                        ClaimsIdentity identity = new ClaimsIdentity(claims, "AuthCookie");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                        AuthenticationProperties properties = new AuthenticationProperties()
                        {
                            IsPersistent = log.RememberMe
                        };
                        await HttpContext.SignInAsync("AuthCookie", claimsPrincipal, properties);
                    }
                    else
                    {
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, temp.Name),
                            new Claim(ClaimTypes.Email, temp.Email),
                        };
                        ClaimsIdentity identity = new ClaimsIdentity(claims, "AuthCookie");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                        AuthenticationProperties properties = new AuthenticationProperties()
                        {
                            IsPersistent = log.RememberMe
                        };
                        await HttpContext.SignInAsync("AuthCookie", claimsPrincipal, properties);
                    }
                }
            }
            return RedirectToAction("Index", "Book");
        }
        
        [HttpGet]
        public IActionResult inscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult inscription(UsersVM user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                Users temp = new Users() { Email = user.Email , Name = user.Name, Password = user.Password};
                _db.AddUser(temp);
                Login(new LoginVM() { Email=user.Email, Password=user.Password });
                return RedirectToAction("Index", "Book");
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            _db.loggedUser = null;
            await HttpContext.SignOutAsync("AuthCookie");
            return RedirectToAction("Index", "Book");
        }
    }
}