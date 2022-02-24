using Exercice4.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4.Interfaces
{
    internal interface IDeformable
    {
        public Figure Deformation(double coefH, double coefV);
    }
}
