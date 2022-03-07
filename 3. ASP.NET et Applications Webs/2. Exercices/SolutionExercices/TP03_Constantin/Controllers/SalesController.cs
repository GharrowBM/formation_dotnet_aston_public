using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable
namespace Bookstore.Controllers
{
    public class SalesController : Controller
    {
        DatabaseMock _db;
        public SalesController(DatabaseMock db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Sales> list = _db.GetSales().FindAll(x => x.Buyer.Id == _db.loggedUser.Id);
            if(list == null)
            {
                _db.AddSale(new Sales() { Buyer = _db.loggedUser , ListBook = new List<Books>()});
            }
            return View(list);
        }
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AllSales()
        {
            List<Sales> list = _db.GetSales();
            return View("Index",list);
        }
        public IActionResult AddSales(int id)
        {
            Books temp = _db.GetByIdBook(id);
            Sales saleOfUsers = _db.GetSales().LastOrDefault(x => x.Buyer.Id == _db.loggedUser.Id);
            if(saleOfUsers == null || saleOfUsers.isFinished == true)
            {
                saleOfUsers = new Sales() { Buyer=_db.loggedUser , ListBook = new List<Books>() };
                _db.AddSale(saleOfUsers);
            }
            saleOfUsers.ListBook.Add(temp);
            return RedirectToAction("Index","Book");
        }
        public IActionResult Panier()
        {
            Sales saleOfUsers = _db.GetSales().LastOrDefault(x => x.Buyer.Id == _db.loggedUser.Id && x.isFinished == false);
            if (saleOfUsers == null)
            {
                saleOfUsers = new Sales() { Buyer = _db.loggedUser, ListBook = new List<Books>() };
                _db.AddSale(saleOfUsers);
            }
            return View(saleOfUsers);
        }

        public IActionResult Validation(int id)
        {
            Sales temp = _db.GetByIdSale(id);
            return View(temp);
        }

        public IActionResult RemoveBookFromSales(int idBook)
        {
            Sales saleOfUsers = _db.GetSales().FirstOrDefault(x => x.Buyer.Id == _db.loggedUser.Id && x.isFinished == false);
            Books toRemove = saleOfUsers.ListBook.Find(x => x.Id == idBook);
            saleOfUsers.ListBook.Remove(toRemove);
            return RedirectToAction("Panier");
        }

        public IActionResult FinishSales()
        {
            Sales saleOfUsers = _db.GetSales().LastOrDefault(x => x.Buyer.Id == _db.loggedUser.Id && x.isFinished == false);
            saleOfUsers.isFinished = true;
            return RedirectToAction("Index", "Book");
        }
    }
}
