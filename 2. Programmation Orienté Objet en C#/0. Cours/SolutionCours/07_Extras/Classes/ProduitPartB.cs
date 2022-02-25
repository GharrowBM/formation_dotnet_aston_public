using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Extras.Classes
{
    internal partial class Product
    {
        private decimal _price;
        private int _stock;
        public Ingredient[] Ingredients { get; private set; }


        public Product(string name, string description, decimal price, int stock)
        {
            _name = name;
            _description = description;
            _price = price;
            _stock = stock;
        }

        public Product(string name, string description, decimal price, int stock, Ingredient[] ingredient) : this (name, description, price, stock)
        {
            Ingredients = ingredient;
        }

        public class Ingredient
        {
            private string _name;
            private string _description;

            public Ingredient(string name, string description)
            {
                this._name = name;
                this._description = description;
            }

            public override string ToString()
            {
                return $"{_name}";
            }
        }

        public override string ToString()
        {
            return $"{_name} ({_price:C2}, Stock : {_stock}) : {_description} | Ingrédients : {(Ingredients is not null ? string.Join<Ingredient>(", ", Ingredients) : "Aucun")}";
        }
    }
}
