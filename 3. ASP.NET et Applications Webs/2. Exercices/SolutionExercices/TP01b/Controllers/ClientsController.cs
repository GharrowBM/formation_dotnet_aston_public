using CaisseEnregistreuse.Controllers.Services;
using CaisseEnregistreuse.Models;
using CaisseEnregistreuse.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CaisseEnregistreuse.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly FakeDB _db;

        public ClientsController(ILogger<ClientsController> logger, FakeDB db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            List<Client> clients = _db.Clients.ToList();

            return View("ClientsList", clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Client client = new() { Email = vm.Email, FirstName = vm.FirstName, LastName = vm.LastName, PhoneNumber = vm.PhoneNumber };

            _db.Clients.Add(client);

            ViewData["MessageAlert"] = new MessageAlertVM() { Content = $"{client.FirstName} ajouté avec succès !", Classes = "alert alert-success" };

            List<Client> clients = _db.Clients.ToList();

            return View("ClientsList", clients);
        }

        public IActionResult Remove(int id)
        {
            Client toDelete = _db.Clients.FirstOrDefault(x => x.Id == id);
            
            if (toDelete == null)
            {
                ViewData["MessageAlert"] = new MessageAlertVM() { Content = $"Aucun client avec l'ID {id} !", Classes = "alert alert-danger" };
            }
            else
            {
                _db.Clients.Remove(toDelete);

                ViewData["MessageAlert"] = new MessageAlertVM() { Content = $"{toDelete.FullName} supprimé avec succès !", Classes = "alert alert-success" };
            }

            List<Client> clients = _db.Clients.ToList();

            return View("ClientsList", clients);

        }
    }
}
