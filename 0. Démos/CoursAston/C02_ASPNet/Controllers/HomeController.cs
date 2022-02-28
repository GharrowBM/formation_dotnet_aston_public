using C02_ASPNet.Controllers.Services;
using C02_ASPNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace C02_ASPNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IGetGuid _guidServiceA;
        //private readonly IGetGuid _guidServiceB;

        private readonly DabaseMock _db;

        //public HomeController(ILogger<HomeController> logger, IGetGuid guidServiceA, IGetGuid guidServiceB)
        //{
        //    _guidServiceA = guidServiceA;
        //    _guidServiceB = guidServiceB;
        //    _list = new List<string>();
        //    _logger = logger;
        //}

        public HomeController(ILogger<HomeController> logger, DabaseMock db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _db.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult GetMyClients()
        {
            List<string> clients = _db.GetAll();
            
            return View("GetIds", clients);
        }

        [HttpPost]
        public IActionResult AddClient(string clientName)
        {
            if(_db.Add(clientName))
            {
                return RedirectToAction("GetMyClients");
            }

            return View("Error");
        }

        public IActionResult RemoveClient(int id) 
        {
            if (_db.Remove(id))
            {
                return RedirectToAction(nameof(GetMyClients));
            }

            return View("Error");
        }

        //public IActionResult GetIds()
        //{
        //    string guidA = _guidServiceA.GetMyId();
        //    string guidB = _guidServiceB.GetMyId();

        //    _list.Add(guidA);
        //    _list.Add(guidB);

        //    return View(_list);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}