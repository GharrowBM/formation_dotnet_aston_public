using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2.Classes
{
    internal class Nouvelle
    {
        private string _sujet;
        private string _description;

        public Nouvelle(string sujet, string description)
        {
            _sujet = sujet;
            _description = description;
        }

        public string Sujet { get => _sujet; }
        public string Description { get => _description; }
    }
}
