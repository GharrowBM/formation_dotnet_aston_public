using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace C02_ASPNet.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
