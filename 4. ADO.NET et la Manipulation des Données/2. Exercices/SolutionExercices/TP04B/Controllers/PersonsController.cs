using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP04B.Datas;
using TP04B.Models;

namespace TP04B.Controllers
{
    public class PersonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Person> people = await _context.People.Include(x => x.Adress).ToListAsync();
            var homelesses = people.Where(x => x.Adress == null).ToList();
            if (homelesses.Count > 0)
            {
                ViewBag.Homelesses = homelesses;
            }

            return View(people);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Adress> adresses = await _context.Adresses.ToListAsync();
            ViewBag.Adresses = new SelectList(adresses, "Id", "FullAdress");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Firstname, Lastname, Phone, Email, AdressId")]Person person)
        {
            List<Adress> adresses;

            if (!ModelState.IsValid)
            {
                adresses = await _context.Adresses.ToListAsync();
                ViewBag.Adresses = new SelectList(adresses, "Id", "FullAdress");

                return View(person);
            }

            person.AdressId = person.AdressId == 0 ? null : person.AdressId;

            await _context.People.AddAsync(person);

            if(await _context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("Erreur", "Il y a eu un problème lors de l'ajout de la personne en base de données");

            adresses = await _context.Adresses.ToListAsync();
            ViewBag.Adresses = new SelectList(adresses, "Id", "FullAdress");

            return View(person);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Person? found = await _context.People.FirstOrDefaultAsync(x => x.Id == id);

            if (found != null)
            {
                List<Adress> adresses = await _context.Adresses.ToListAsync();
                ViewBag.Adresses = new SelectList(adresses, "Id", "FullAdress");

                return View(found);

            }

            return View("Error");

        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id, Firstname, Lastname, Phone, Email, AdressId")] Person person)
        {
            if (!ModelState.IsValid)
            {
                List<Adress> adresses = await _context.Adresses.ToListAsync();
                ViewBag.Adresses = new SelectList(adresses, "Id", "FullAdress");

                return View(person);
            }

            Person? found = await _context.People.FirstOrDefaultAsync(x => x.Id == person.Id);

            if (found != null)
            {
                found.Firstname = person.Firstname;
                found.Lastname = person.Lastname;
                found.Email = person.Email;
                found.Phone = person.Phone;
                found.AdressId = person.AdressId == 0 ? null : person.AdressId;


                _context.People.Update(found);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Erreur", "Il y a eu un problème lors de l'édition de la personne en base de données");

                List<Adress> adresses = await _context.Adresses.ToListAsync();
                ViewBag.Adresses = new SelectList(adresses, "Id", "FullAdress");

                return View(found);

            }

            return View("Error");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Person? found = await _context.People.FirstOrDefaultAsync(x => x.Id == id);

            if (found != null)
            {
                _context.People.Remove(found);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("Index");
                }

            }

            return View("Error");
        }
    }
}
