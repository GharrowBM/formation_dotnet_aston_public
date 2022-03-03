using C02_ASPNet.Controllers.Services;
using Microsoft.AspNetCore.Mvc;

namespace C02_ASPNet.ViewComponents
{
    public class DogSummary : ViewComponent
    {
        private readonly DabaseMock _db;

        public DogSummary(DabaseMock db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke() // Un ViewComponent est appellé par sa méthode invoque, de façon asynchrone par la Classe Component dans une vue.
        {
            // Contrairement à une partialView, on peut gérer des informations du serveur avant l'affichage de la "partial view" 

            return View(_db.Dogs.Count);
        }
    }
}
