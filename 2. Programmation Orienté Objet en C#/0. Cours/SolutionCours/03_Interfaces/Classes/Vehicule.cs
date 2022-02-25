using _03_Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Interfaces.Classes
{
    internal abstract class Vehicule : IVehicule
    {
        protected string _model;
        protected string _brand;
        protected DateTime _dateOfManufacturing;
        protected bool _isStarted;

        public string Model { get => _model; }
        public string Brand { get => _brand; }
        public DateTime DateOfManufacturing { get => _dateOfManufacturing; }
        public bool IsStarted { get => _isStarted; }

        public Vehicule(string model, string brand)
        {
            _model = model;
            _brand = brand;
            _dateOfManufacturing = DateTime.Now;
            _isStarted = false;
        }

        public Vehicule(string model, string brand, DateTime dateOfManufacturing) : this(model, brand)
        {
            _dateOfManufacturing = dateOfManufacturing;
        }

        /*
         * En implémentant l'interface, on se voir forcé de redéfinir les méthodes lui étant associées sous peine de ne pas pouvoir compiler
         * 
         * Cette implémentation doit se faire pour chaque interface héritée par la classe actuelle, mais elles ne doivent pas forcément être fonctionnelles 
         * et peuvent simplement lever une Exception spécifiant leur absence d'implémentation => throw new NotImplementedException();
         */

        public virtual void Start()
        {
            _isStarted = true;

            Console.WriteLine("La voiture démarre !");
        }

        public virtual void Stop()
        {
            Console.WriteLine("La voiture s'arrête...");
        }

        public virtual void Move(double kilometers)
        {
            if (_isStarted) Console.WriteLine($"LA voiture bouge de {kilometers:N0} km");
            else Console.WriteLine("LA voiture est à l'arrêt et ne bouge pas...");
        }
    }
}
