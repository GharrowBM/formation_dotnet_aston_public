using Microsoft.AspNetCore.Mvc;
using Bookstore.Controllers;
namespace Bookstore.ViewComponents
{
    public class PanierNumber : ViewComponent
    {
        DatabaseMock databaseMock;

        public PanierNumber(DatabaseMock _db)
        {
            databaseMock = _db;
        }

        public IViewComponentResult Invoke() // Un ViewComponent est appellé par sa méthode invoque, de façon asynchrone par la Classe Component dans une vue.
        {
            int numberOfBook = 0;
            Sales saleOfUsers = databaseMock.GetSales().LastOrDefault(x => x.Buyer.Id == databaseMock.loggedUser.Id && x.isFinished == false);
            if(saleOfUsers == null)
            {
                numberOfBook = 0;
            }
            else
            {
                numberOfBook = saleOfUsers.ListBook.Count();
            }
            return View(numberOfBook);
        }
    }
}
