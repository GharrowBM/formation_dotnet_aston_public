using C05_EFCore.Datas;
using C05_EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace C05_EFCore.Controllers
{
    public class DogController : Controller
    {
        private readonly IRepository<Dog> _dogRepo;
        private readonly IRepository<Master> _masterRepo;

        public DogController(IRepository<Dog> dogRepo, IRepository<Master> masterRepo)
        {
            _dogRepo = dogRepo;
            _masterRepo = masterRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Dog> dogs = _dogRepo.GetAll().ToList();
            return View(dogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Masters = new SelectList(_masterRepo.GetAll().ToList(), "Id", "Fullname");

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, CollarColor, Age, MasterId")] Dog newDog)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Masters = new SelectList(_masterRepo.GetAll().ToList(), "Id", "Fullname");
                return View(newDog);
            }

            _dogRepo.AddOrUpdate(newDog);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Dog found = _dogRepo.GetById(id);
            ViewBag.Masters = new SelectList(_masterRepo.GetAll().ToList(), "Id", "Fullname");

            return View(found);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Name, CollarColor, Age, MasterId")] Dog newDog)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Masters = new SelectList(_masterRepo.GetAll().ToList(), "Id", "Fullname");
                return View(newDog);
            }

            _dogRepo.AddOrUpdate(newDog);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _dogRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
