using C02_ASPNet.Controllers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace C02_ASPNet.Controllers
{
    [Authorize]
    public class PictureController : Controller
    {
        private readonly UploadService _uploadService;
        private readonly DabaseMock _db;

        public PictureController(UploadService uploadService, DabaseMock db)
        {
            _uploadService = uploadService;
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.PictureURL = _db.PictureURL;

            return View();
        }

        public IActionResult UploadPicture(IFormFile picture)
        {
            _db.PictureURL = _uploadService.UploadPicture(picture, "chiens");

            return RedirectToAction("Index");
        }
    }
}
