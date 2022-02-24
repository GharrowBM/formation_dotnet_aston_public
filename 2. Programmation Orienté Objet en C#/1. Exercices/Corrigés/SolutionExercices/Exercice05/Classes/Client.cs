using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice5.Classes
{
    internal class Client
    {
        private string _nom;
        private string _prenom;
        private string _telephone;

        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Telephone { get => _telephone; set => _telephone = value; }

        public Client(string nom, string prenom, string telephone)
        {
            _nom = nom;
            _prenom = prenom;
            _telephone = telephone;
        }

        public override string ToString()
        {
            return $"{Prenom} {Nom} : {Telephone}";
        }
    }
}
