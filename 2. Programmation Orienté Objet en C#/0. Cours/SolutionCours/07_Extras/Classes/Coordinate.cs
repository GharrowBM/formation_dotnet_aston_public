using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Extras.Classes
{
    internal struct Coordinate
    {
        public double X { get; init; }
        public double Y { get; init; }

        public double GetDistanceFromOrigin()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public override string ToString()
        {
            return $"({X:N2};{Y:N2})";
        }
    }
}
