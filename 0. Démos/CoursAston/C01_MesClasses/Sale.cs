using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public class Sale
    {
        private string _productName;
        private decimal _price;

        public event Action<decimal> Promotion;

        public string ProductName { get => _productName;  }
        public decimal Price { get => _price; }

        public Sale(string productName, decimal price)
        {
            _productName = productName;
            _price = price;
        }

        public void Reduction(decimal amount)
        {
            _price -= amount;

            //if (Promotion != null)
            //{
            //    Promotion(amount);
            //}

            Promotion?.Invoke(_price);
        }
    }
}
