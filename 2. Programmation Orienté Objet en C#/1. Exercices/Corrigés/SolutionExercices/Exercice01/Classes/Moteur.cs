using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1.Classes
{
    internal class Moteur
    {
        private double _volumeReservoir;
        private double _volumeTotal;
        private bool _demarre;

        public double VolumeReservoir { get => Math.Round(_volumeReservoir, 2); set => _volumeReservoir = value; }
        public double VolumeTotal { get => Math.Round(_volumeTotal, 2); set => _volumeTotal = value; }
        public bool Demarre { get => _demarre; set => _demarre = value; }

        public Moteur(double volumeTotal)
        {
            _volumeReservoir = _volumeTotal = volumeTotal;
            _demarre = false;
        }

        public bool Demarrer()
        {
            if (VolumeReservoir > 0.1 && !Demarre)
            {
                VolumeReservoir -= 0.1;
                Demarre = true;
                Console.WriteLine("Je démarre");
                return true;
            }

            return false;
        }

        public double Utiliser(double volume)
        {
            if (!Demarre) Demarrer();
            if (VolumeReservoir >= volume)
            {
                VolumeReservoir -= volume;
                Console.WriteLine($"J'utilise {volume} litres");
            }
            else
            {
                Console.WriteLine($"J'utilise {VolumeReservoir} litres");
                VolumeReservoir = 0;
            }
            
            return VolumeReservoir;
        }

        public void FaireLePlein(double volume)
        {
            if (volume > VolumeTotal)
            {
                VolumeReservoir = VolumeTotal;
                Console.WriteLine($"Je me remplis de {VolumeTotal} litres");
            }
            else
            {
                VolumeReservoir = volume;
                Console.WriteLine($"Je me remplis de {volume} litres");
            }
        }

        public void Arreter()
        {
            if (Demarre)
            {
                Demarre = false;
                Console.WriteLine("Je m'arrête");
            }
        }
    }
}
