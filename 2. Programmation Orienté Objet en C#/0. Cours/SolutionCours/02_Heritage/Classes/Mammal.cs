using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Heritage.Classes
{
    internal abstract class Mammal : Animal
    {
        protected int _limbs;

        public int Limbs { get => _limbs; set => _limbs = value; }

        public Mammal(string name, int age, bool isProtected, int limbs) : base(name, age, isProtected)
        {
            _limbs = limbs;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{_name} fait un bruit de mammifère !");
        }
    }
}
