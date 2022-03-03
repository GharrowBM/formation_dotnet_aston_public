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

        public IViewComponentResult Invoke()
        {
            return View(_db.Dogs.Count);
        }
    }
}
