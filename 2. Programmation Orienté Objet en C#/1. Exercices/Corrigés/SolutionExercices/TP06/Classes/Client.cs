using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06.Classes
{
    internal class Client
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _telephone;

        public static int compteurClients;

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Telephone { get => _telephone; set => _telephone = value; }

        public Client(string nom, string prenom, string telephone)
        {
            _id = ++compteurClients;
            _nom = nom;
            _prenom = prenom;
            _telephone = telephone;
        }
    }
}
