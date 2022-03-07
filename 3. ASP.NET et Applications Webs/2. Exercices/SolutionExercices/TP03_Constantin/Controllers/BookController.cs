using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        DatabaseMock _db;
        public BookController(DatabaseMock db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.GetBooks());
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Add()
        {
            ViewBag.Authors = new SelectList(_db.GetAuthors().ToList(), "Id", "FullName");
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Add(BooksVM book)
        {
            if (ModelState.IsValid)
            {
                _db.AddBook(new Books
                {
                    Title = book.Title,
                    Description = book.Description,
                    Price = book.Price,
                    Image = book.Image,
                    ISBN = book.ISBN,
                    ListCategory = book.ListCategory,
                    DateParution = book.DateParution,
                    Author = _db.GetByIdAuthor(book.AuthorId),
                });
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Authors = new SelectList(_db.GetAuthors().ToList(), "Id", "FullName");
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Books temp = _db.GetByIdBook(id);
            BooksVM books = new BooksVM()
            {
                Title = temp.Title,
                Description = temp.Description,
                Id = id,
                ISBN = temp.ISBN,
                Image = temp.Image,
                Price = temp.Price,
                DateParution = temp.DateParution,
                ListCategory = temp.ListCategory,
                AuthorId = temp.Author.Id
            };
            ViewBag.Authors = new SelectList(_db.GetAuthors().ToList(), "Id", "FullName");
            return View(books);
        }
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Details(BooksVM book)
        {
            _db.UpdateBook(book);
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Remove(int id)
        {
            _db.DeleteBook(_db.GetByIdBook(id));
            return RedirectToAction("Index");
        }
    }
}
