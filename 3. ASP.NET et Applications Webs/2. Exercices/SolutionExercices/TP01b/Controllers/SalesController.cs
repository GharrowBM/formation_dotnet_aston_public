using CaisseEnregistreuse.Controllers.Services;
using CaisseEnregistreuse.Models;
using CaisseEnregistreuse.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaisseEnregistreuse.Controllers
{
    public class SalesController : Controller
    {
        private readonly ILogger<SalesController> _logger;
        private readonly FakeDB _db;

        public SalesController(ILogger<SalesController> logger, FakeDB db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            List<Sale> sales = _db.Sales.ToList();

            return View("SaleList", sales);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Products = new SelectList(_db.Products.ToList(), "Id", "Name");
            ViewBag.Clients = new SelectList(_db.Clients.ToList(), "Id", "FullName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(SaleVM sale)
        {
            if (!ModelState.IsValid)
            {
                return View(sale);
            }
            Sale newSale = new()
            {
                Client = _db.Clients.FirstOrDefault(x => x.Id == sale.ClientId)
            };

            foreach(int id in sale.ProductIds) newSale.Products.Add(_db.Products.FirstOrDefault(x => x.Id == id));

            _db.Sales.Add(newSale);

            ViewData["MessageAlert"] = new MessageAlertVM() { Content = $"Vente n°{newSale.Id} ajoutée avec succès !", Classes = "alert alert-success" };

            List<Sale> sales = _db.Sales.ToList();

            return View("SaleList", sales);
        }

        public IActionResult Remove(int id)
        {
            Sale toDelete = _db.Sales.FirstOrDefault(x => x.Id == id);

            if (toDelete == null)
            {
                ViewData["MessageAlert"] = new MessageAlertVM() { Content = $"Aucune vente avec l'ID {id} !", Classes = "alert alert-danger" };
            }
            else
            {
                _db.Sales.Remove(toDelete);

                ViewData["MessageAlert"] = new MessageAlertVM() { Content = $"Vente n°v{toDelete.Id} supprimée avec succès !", Classes = "alert alert-success" };
            }

            List<Sale> sales = _db.Sales.ToList();

            return View("SaleList", sales);

        }
    }
}
