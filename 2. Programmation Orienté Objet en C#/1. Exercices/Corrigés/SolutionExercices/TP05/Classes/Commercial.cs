using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP05.Classes
{
    internal class Commercial : Salarie
    {
        private double _chiffreAffaire;
        private int _comission;
        public double ChiffreAffaire { get => _chiffreAffaire; set => _chiffreAffaire = value; }
        public int Comission { get => _comission; set => _comission = value; }
        public Commercial(string categorie, string service, string nom, double salaire, double chiffreAffaire, int comission) : base(categorie, service, nom, salaire)
        {
            _chiffreAffaire = chiffreAffaire;
            _comission = comission;
        }

        public override void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire du commercial {Nom} est de {Math.Round(Salaire + ChiffreAffaire * ((double) Comission / 100), 2)} euros");
        }

    }
}
