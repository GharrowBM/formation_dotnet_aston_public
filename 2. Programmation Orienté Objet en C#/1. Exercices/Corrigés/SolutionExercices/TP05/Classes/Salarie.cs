using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP05.Classes
{
    internal class Salarie
    {
        private int _matricule;
        private string _categorie;
        private string _service;
        private string _nom;
        private double _salaire;
        public static int NombreSalaries;
        public static double TotalSalaires;

        public int Matricule { get => _matricule; set => _matricule = value; }
        public string Categorie { get => _categorie; set => _categorie = value; }
        public string Service { get => _service; set => _service = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public double Salaire { get => _salaire; set => _salaire = value; }

        public Salarie(string categorie, string service, string nom, double salaire)
        {
            _matricule = ++NombreSalaries;
            _categorie = categorie;
            _service = service;
            _nom = nom;
            _salaire = salaire;
            TotalSalaires += _salaire;
        }

        public virtual void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire de l'employé {Nom} est de {Math.Round(Salaire, 2)} euros");
        }

        public static void ChangerCompteurA(int nouvelleValeur = 0)
        {
            NombreSalaries = nouvelleValeur;
        }
    }
}
