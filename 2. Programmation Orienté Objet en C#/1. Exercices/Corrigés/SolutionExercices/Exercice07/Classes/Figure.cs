using Exercice07.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07.Classes
{
    internal abstract class Figure
    {
        protected Coordonnees _coordonnees;

        public Figure(double x, double y)
        {
            _coordonnees = new Coordonnees(x, y);
        }

        public virtual void Afficher()
        {
            Console.WriteLine($"La figure a pour centre : ({_coordonnees.X};{_coordonnees.Y})");
        }
    }
}
