using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Extras.Classes
{
    internal class Sale
    {
        private Client _client;
        private List<Product> _produits;

        public Sale(Client client, List<Product> produits)
        {
            _client = client;
            _produits = produits;
        }

        public void PrintSale()
        {
            Console.WriteLine($"Vente associée à {_client}");
            _produits.ForEach(p =>
            {
                Console.WriteLine("\t{0}", p);
            });
        }
    }
}
