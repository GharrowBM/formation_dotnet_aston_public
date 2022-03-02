using CaisseEnregistreuse.Models;

namespace CaisseEnregistreuse.Controllers.Services
{
    public class FakeDB
    {
        private List<Client> _clients;
        private List<Product> _products;
        private List<Sale> _sales;

        public List<Client> Clients { get { return _clients; } }
        public List<Product> Products { get { return _products; } }
        public List<Sale> Sales { get { return _sales;} }

        public FakeDB()
        {
            _clients = new List<Client>();
            _products = new List<Product>();
            _sales = new List<Sale>();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if(!_clients.Any())
            {

            }

            if(!_products.Any())
            {

            }

            if (!_sales.Any())
            {

            }
        }

    }
}
