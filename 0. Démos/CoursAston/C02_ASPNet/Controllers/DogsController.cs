using C02_ASPNet.Controllers.Services;
using C02_ASPNet.Models;
using C02_ASPNet.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace C02_ASPNet.Controllers
{
    public class DogsController : Controller
    {
        private readonly DabaseMock _db;

        public DogsController(DabaseMock db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Dogs.ToList());
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Add()
        {
            ViewBag.Masters = new SelectList(_db.Persons.ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Add(DogVM dog)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Masters = new SelectList(_db.Persons.ToList(), "Id", "Name");

                return View(dog);
            }

            Dog newDog = new() { Name = dog.Name, CollarColor = dog.CollarColor, NbOfLegs = dog.NbOfLegs, Master = _db.Persons.FirstOrDefault(x => x.Id == dog.MasterId) };

            _db.Dogs.Add(newDog);

            return RedirectToAction("Index");

        }
    }
}
