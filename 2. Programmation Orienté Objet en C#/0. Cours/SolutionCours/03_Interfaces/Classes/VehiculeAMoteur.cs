using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Interfaces.Classes
{
    internal abstract class VehiculeAMoteur : Vehicule
    {
        protected Engine _engine;
        public Engine Engine { get => _engine; set => _engine = value; }
        protected VehiculeAMoteur(string model, string brand, double engineVolume) : base(model, brand)
        {
            _engine = new(engineVolume);
        }

        protected VehiculeAMoteur(string model, string brand, DateTime dateOfManufacturing, double engineVolume) : base(model, brand, dateOfManufacturing)
        {
            _engine = new(engineVolume);
        }

        public override void Start()
        {
            _engine.SwitchRunning();
        }

        public override void Stop()
        {
            _engine.SwitchRunning();
        }

        public override void Move(double kilometers)
        {
            _engine.Run(kilometers);
        }
    }
}
