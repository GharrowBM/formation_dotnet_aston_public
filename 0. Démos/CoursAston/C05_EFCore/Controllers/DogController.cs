using C05_EFCore.Datas;
using C05_EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace C05_EFCore.Controllers
{
    public class DogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Dog> dogs = _context.Dogs.ToList();

            return View(dogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, CollarColor, Age")] Dog newDog)
        {
            if (!ModelState.IsValid)
            {
                return View(newDog);
            }

            _context.Dogs.Add(newDog);

            if(_context.SaveChanges() > 0) return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("Erreur", "Ajout en Base de données impossible !");
                return View(newDog);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Dog found = _context.Dogs.FirstOrDefault(x => x.Id == id);

            if (found != null) return View(found);
            else return View("Error");
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Name, CollarColor, Age")] Dog newDog)
        {
            if (!ModelState.IsValid)
            {
                return View(newDog);
            }

            Dog found = _context.Dogs.FirstOrDefault(x => x.Id == newDog.Id);

            found.Name = newDog.Name;
            found.Age = newDog.Age;
            found.CollarColor = newDog.CollarColor;

            _context.Dogs.Update(found);
            if (_context.SaveChanges() > 0) return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("Erreur", "Edition en Base de données impossible !");
                return View(newDog);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _context.Dogs.Remove(_context.Dogs.FirstOrDefault(x => x.Id == id));
            if (_context.SaveChanges() > 0) return RedirectToAction("Index");
            else
            {
                return View("Error");
            }
        }
    }
}
