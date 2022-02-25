using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Interfaces.Interfaces
{
    /*
     * La création d'une interface permet de fixer des méthodes qui devront être utilisée par les classes qui implémenteront cette interface 
     * 
     * Contrairement à une classe abstraite, il est possible d'hériter d'autant d'interfaces que l'on le veut.
     * 
     */

    internal interface IVehicule
    {
        /*
         * Les méthodes ci-dessous devront être comprises dans chaque classe implémentant cette interface. C'est une sorte de contrat que la classe
         * doit remplir pour être valide
         * 
         */

        public void Start();
        public void Stop();
        public void Move(double kilometers);

    }
}
