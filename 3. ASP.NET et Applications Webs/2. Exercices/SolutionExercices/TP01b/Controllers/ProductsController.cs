using CaisseEnregistreuse.Controllers.Services;
using CaisseEnregistreuse.Models;
using Microsoft.AspNetCore.Mvc;
using CaisseEnregistreuse.Models.ViewModels;

namespace CaisseEnregistreuse.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly FakeDB _db;

        public ProductsController(ILogger<ProductsController> logger, FakeDB db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            List<Product> products = _db.Products.ToList();

            return View("ProductsList", products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Product product = new() { Name = vm.Name, Description = vm.Description, Price= vm.Price };

            _db.Products.Add(product);

            ViewData["MessageAlert"] = new MessageAlertVM() { Content = $"{product.Name} ajouté avec succès !", Classes = "alert alert-success" };

            List<Product> products = _db.Products.ToList();

            return View("ProductsList", products);
        }

        public IActionResult Remove(int id)
        {
            Product toDelete = _db.Products.FirstOrDefault(x => x.Id == id);

            if (toDelete == null)
            {
                ViewData["MessageAlert"] = new MessageAlertVM() { Content = $"Aucun produit avec l'ID {id} !", Classes = "alert alert-danger" };
            }
            else
            {
                _db.Products.Remove(toDelete);

                ViewData["MessageAlert"] = new MessageAlertVM() { Content = $"{toDelete.Name} supprimé avec succès !", Classes = "alert alert-success" };
            }

            List<Product> products = _db.Products.ToList();

            return View("ProductsList", products);

        }
    }
}
