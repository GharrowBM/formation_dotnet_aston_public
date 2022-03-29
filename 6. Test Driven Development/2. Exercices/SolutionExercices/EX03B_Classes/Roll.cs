using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03B_Classes
{
    public class Roll
    {
        private int _pins;
        public int Pins { get => _pins; }
        public Roll(int p)
        {
            _pins = p;
        }
    }
}
