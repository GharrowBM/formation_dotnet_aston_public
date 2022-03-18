using C05_EFCore.Datas;
using C05_EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace C05_EFCore.Controllers
{
    public class AdressController : Controller
    {
        private readonly IRepository<Adress> _adressRepo;

        public AdressController(IRepository<Adress> adressRepo)
        {
            _adressRepo = adressRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Adress> adresses = _adressRepo.GetAll().ToList();
            return View(adresses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("StreetNumber, StreetName, PostalCode, CityName")] Adress newAdress)
        {
            if (!ModelState.IsValid)
            {
                return View(newAdress);
            }

            _adressRepo.AddOrUpdate(newAdress);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Adress found = _adressRepo.GetById(id);

            return View(found);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, StreetNumber, StreetName, PostalCode, CityName")] Adress newAdress)
        {
            if (!ModelState.IsValid)
            {
                return View(newAdress);
            }

            _adressRepo.AddOrUpdate(newAdress);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _adressRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
