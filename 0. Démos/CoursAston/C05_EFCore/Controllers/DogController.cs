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

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Dog found = _context.Dogs.FirstOrDefault(x => x.Id == id);

            return View(found);
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
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _context.Dogs.Remove(_context.Dogs.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
