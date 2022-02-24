using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02.Classes
{
    public class Chaise
    {
        private int _nbPieds;
        private string _couleur;
        private string _materiaux;
        public int NbPieds { get => _nbPieds; set => _nbPieds = value; }
        public string Couleur { get => _couleur; set => _couleur = value; }
        public string Materiaux { get => _materiaux; set => _materiaux = value; }

        public Chaise()
        {
            _nbPieds = 4;
            _couleur = "Blanche";
            _materiaux = "Bois";
        }

        public Chaise(int nbPieds, string couleur, string materiaux)
        {
            _nbPieds = nbPieds;
            _couleur = couleur;
            _materiaux = materiaux;
        }

    }
}
