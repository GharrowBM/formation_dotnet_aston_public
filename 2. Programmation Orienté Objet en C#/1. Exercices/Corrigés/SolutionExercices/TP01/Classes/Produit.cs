using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Classes
{
    internal class Produit
    {
        private int _id;
        private string _nom;
        private int _stock;
        private double _price;

        public static int compteur;

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public double Price { get => _price; set => _price = value; }

        public Produit(string nom, int stock, double price)
        {
            _id = ++compteur;
            _nom = nom;
            _stock = stock;
            _price = price;
        }
    }
}
