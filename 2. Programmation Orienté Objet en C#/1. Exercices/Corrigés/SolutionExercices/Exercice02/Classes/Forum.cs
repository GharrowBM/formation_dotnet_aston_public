using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2.Classes
{
    internal class Forum
    {
        private string _nom;
        private DateTime _dateCreation;
        private Moderateur _moderateur;
        private Nouvelle[] _nouvelles;
        private Abonne[] _abonnes;
        internal Moderateur Moderateur { get => _moderateur; set => _moderateur = value; }
        internal Nouvelle[] Nouvelles 
        { 
            get 
            {

                return _nouvelles;
            } 
        }
        internal Abonne[] Abonnes 
        { 
            get 
            {

                return _abonnes;
            }  
        }

        public Forum(string nom, int nbNouvelles, int nbAbonnes)
        {
            _nom = nom;
            _dateCreation = DateTime.Now;
            _nouvelles = new Nouvelle[nbNouvelles];
            _abonnes = new Abonne[nbAbonnes];
        }
    }
}
