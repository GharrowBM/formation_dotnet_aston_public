using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Extras.Classes
{
    internal partial class Product
    {
        private string _name;
        private string _description;

        public void SayTaxes(string countryCode)
        {
            double taxes = 0;

            switch (countryCode)
            {
                case "FR":
                case "GB":
                    taxes = 0.20;
                    break;
                case "US":
                    taxes = 0.08;
                    break;
                default:
                    taxes = 0.05;
                    break;
            }

            decimal finalPrice = _price + Decimal.Multiply(_price, (decimal) taxes);

            Console.WriteLine($"{_name} Prix HT : {_price:C2} / T.V.A. : {finalPrice - _price:C2} / Prix T.T.C. {finalPrice:C2}");
        }
    }
}
