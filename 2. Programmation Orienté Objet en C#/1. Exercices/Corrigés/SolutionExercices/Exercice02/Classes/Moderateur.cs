using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2.Classes
{
    internal class Moderateur : Abonne
    {
        public Moderateur(string prenom, string nom, int age, Forum forum) : base(prenom, nom, age, forum)
        {
        }

        public bool SupprimerNouvelle(int index)
        {
            Nouvelle nouvelleASupprimer = _forum.Nouvelles[index];
            if (nouvelleASupprimer != null)
            {
                _forum.Nouvelles[index] = null;
                return true;
            }

            return false;
        }

        public bool BannirAbonne(int index)
        {
            Abonne abonneASupprimer = _forum.Abonnes[index];
            if (abonneASupprimer != null)
            {
                _forum.Abonnes[index] = null;
                return true;
            }

            return false;
        }

        public bool AjouterAbonne(Abonne abonne)
        {
            int firstNull = Array.FindIndex(_forum.Abonnes, a => a == null);
            if (firstNull != -1)
            {
                _forum.Abonnes[firstNull] = abonne;
                return true;
            }

            return false;
        }

        public void ListerAbonnes()
        {
            foreach (Abonne abonne in _forum.Abonnes)
            {
                if (abonne != null ) Console.WriteLine($"{Array.FindIndex(_forum.Abonnes, a => a == abonne)}. {abonne.Prenom} {abonne.Nom} a {abonne.Age} ans");
            }
            
        }

        public void ListerNouvelles()
        {
            foreach(Nouvelle nouvelle in _forum.Nouvelles)
            {
                if (nouvelle != null ) Console.WriteLine($"{Array.FindIndex(_forum.Nouvelles, n => n == nouvelle)}. {nouvelle.Sujet}");
            }
        }
    }
}
