using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP04B.Datas;
using TP04B.Models;

namespace TP04B.Controllers
{
    public class AdressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Adress> adresses = await _context.Adresses.Include(x => x.Persons).ToListAsync();

            return View(adresses);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("StreetNumber, StreetName, PostalCode, CityName, RegionName, CountryName")] Adress adress)
        {
            List<Person> people; 

            if (!ModelState.IsValid)
            {

                return View(adress);
            }

            await _context.Adresses.AddAsync(adress);

            if (await _context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("Erreur", "Il y a eu un problème lors de l'ajout de l'adresse en base de données");


            return View(adress);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Adress? found = await _context.Adresses.FirstOrDefaultAsync(x => x.Id == id);

            if (found != null)
            {

                return View(found);

            }

            return View("Error");

        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id, StreetNumber, StreetName, PostalCode, CityName, RegionName, CountryName")] Adress adress)
        {
            if (!ModelState.IsValid)
            {

                return View(adress);
            }

            Adress? found = await _context.Adresses.FirstOrDefaultAsync(x => x.Id == adress.Id);

            if (found != null)
            {
                found.StreetNumber = adress.StreetNumber;
                found.StreetName = adress.StreetName;
                found.PostalCode = adress.PostalCode;
                found.CityName = adress.CityName;
                found.RegionName = adress.RegionName;
                found.CountryName = adress.CountryName;

                _context.Adresses.Update(found);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Erreur", "Il y a eu un problème lors de l'édition de l'adresse en base de données");


                return View(found);

            }

            return View("Error");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Adress? found = await _context.Adresses.FirstOrDefaultAsync(x => x.Id == id);

            if (found != null)
            {
                _context.Adresses.Remove(found);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("Index");
                }

            }

            return View("Error");
        }
    }
}
