using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP03.Classes
{
    internal class Produit
    {
        public int Id { get; set; }
        public static int Compteur { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Produit()
        {
            Id = ++Compteur;
        }
    }
}
