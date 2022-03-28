using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08_Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public decimal GetPrice(Customer customer)
        {
            if (customer.IsPlatinum)
            {
                return decimal.Multiply(Price, .8m);
            }

            return Price;
        }

        public decimal GetPrice(ICustomer customer) // Ici, la création d'une nouvelle méthode est nécessaire pour l'abus du Mocking
        {
            if (customer.IsPlatinum)
            {
                return decimal.Multiply(Price, .8m);
            }

            return Price;
        }
    }
}
