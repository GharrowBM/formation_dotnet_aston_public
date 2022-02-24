using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4.Classes
{
    internal class IHM
    {
        public void Demarrer()
        {
            Carre figureA = new Carre(1, 1, 5);
            Rectangle figureB = new Rectangle(5, 10, 2, 10);
            Triangle figureC = new Triangle(-4, -4, 5, 10);
            Figure figureD = figureA.Deformation(5, 2);
            Figure figureE = figureA.Deformation(5, 5);
            Figure figureF = figureB.Deformation(1, 5);
            Figure figureG = figureB.Deformation(5, 10);

            Figure[] figures = new Figure[] { figureA, figureB, figureC, figureD, figureE, figureF, figureG };
            foreach (Figure figure in figures) figure.Affiche();
        }
    }
}
