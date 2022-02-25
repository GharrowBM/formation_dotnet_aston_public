using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2.Classes
{
    internal class Abonne
    {
        protected string _prenom;
        protected string _nom;
        protected int _age;
        protected Forum _forum;

        public string Prenom { get => _prenom;}
        public string Nom { get => _nom; }
        public int Age { get => _age; }

        public Abonne(string prenom, string nom, int age, Forum forum)
        {
            _prenom = prenom;
            _nom = nom;
            _age = age;
            _forum = forum;
        }

        public bool AjouterNouvelle(Nouvelle nouvelle)
        {
            int indiceLibre = Array.FindIndex(_forum.Nouvelles, n => n == null);
            if (indiceLibre != -1)
            {
                _forum.Nouvelles[indiceLibre] = nouvelle;
                return true;
            }

            return false;
        }

        public Nouvelle CreerNouvelle(string nom, string description)
        {
            return new Nouvelle(nom, description);
        }

        public bool AjouterReponse(Nouvelle reponse, int indexPrecedent)
        {  
            int indiceLibre = Array.FindIndex(_forum.Nouvelles, n => n == null);
            if (indiceLibre != -1)
            {
                _forum.Nouvelles[indiceLibre] = reponse;
                return true;
            }

            return false;
        }

        public void ConsulterNouvelle(int index)
        {
            if (_forum.Nouvelles[index] != null) Console.WriteLine($"{_forum.Nouvelles[index].Sujet} : {_forum.Nouvelles[index].Description}");
            else Console.WriteLine("Il n'y a pas de nouvelle à cet indice !");
        }
    }
}
