using C05_EFCore.Datas;
using C05_EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace C05_EFCore.Controllers
{
    public class MasterController : Controller
    {
        private readonly IRepository<Master> _masterRepo;
        private readonly IRepository<Adress> _adressRepo;

        public MasterController(IRepository<Master> masterRepo, IRepository<Adress> adressRepo)
        {
            _masterRepo = masterRepo;
            _adressRepo = adressRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Master> masters = _masterRepo.GetAll().ToList();
            return View(masters);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Adresses = new SelectList(_adressRepo.GetAll().ToList(), "Id", "FullAdress");

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Firstname, Lastname, Email, Phone, AdressId")] Master newMaster)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Adresses = new SelectList(_adressRepo.GetAll().ToList(), "Id", "FullAdress");
                return View(newMaster);
            }

            _masterRepo.AddOrUpdate(newMaster);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Master found = _masterRepo.GetById(id);
            ViewBag.Adresses = new SelectList(_adressRepo.GetAll().ToList(), "Id", "FullAdress");

            return View(found);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Firstname, Lastname, Email, Phone, AdressId")] Master newMaster)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Adresses = new SelectList(_adressRepo.GetAll().ToList(), "Id", "FullAdress");
                return View(newMaster);
            }

            _masterRepo.AddOrUpdate(newMaster);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _masterRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
