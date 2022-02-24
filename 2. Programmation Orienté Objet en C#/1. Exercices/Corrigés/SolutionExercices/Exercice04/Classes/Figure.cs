using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4.Classes
{
    internal abstract class Figure
    {
        protected double _posX;
        protected double _posY;

        protected Figure(double posX, double posY)
        {
            _posX = posX;
            _posY = posY;
        }

        public abstract void Affiche();
    }
}
