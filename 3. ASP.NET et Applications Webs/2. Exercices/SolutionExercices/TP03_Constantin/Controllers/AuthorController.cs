using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class AuthorController : Controller
    {
        DatabaseMock _db;
        public AuthorController(DatabaseMock db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.GetAuthors());
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Authors temp = _db.GetByIdAuthor(id);
            AuthorsVM authors = new AuthorsVM()
            {
                FullName = temp.FullName,
                BirthDate = temp.BirthDate,
                Biography = temp.Biography,
                DeathDate = temp.DeathDate,
                Id = id
            };
            return View(authors);
        }
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Details(AuthorsVM authors)
        {
            _db.UpdateAuthor(authors);
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Remove(int id)
        {
            _db.DeleteAuthor(_db.GetByIdAuthor(id));
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public IActionResult Add(AuthorsVM authors)
        {
            if (ModelState.IsValid)
            {
                _db.AddAuthor(new Authors
                {
                    FullName = authors.FullName,
                    Biography = authors.Biography,
                    BirthDate = authors.BirthDate,
                    DeathDate = authors.DeathDate,
                });
                return RedirectToAction("Index");
            }
            else
            {
                return View(authors);
            }
        }
    }
}