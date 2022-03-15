using Microsoft.AspNetCore.Mvc;

namespace TP06.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
