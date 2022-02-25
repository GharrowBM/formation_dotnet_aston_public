using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Heritage.Classes
{
    internal class Dog : Mammal
    {
        public Dog(string name, int age, bool isProtected, int limbs) : base(name, age, isProtected, limbs)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{_name} dit : WOOF WOOF ! (Ecureuil !)");
        }

        public override void Move(string wayOfMoving)
        {
            Console.WriteLine("Le chien suit son maître et repère le danger pour lui. Pour cela, il se sert de : {0}" , 
                arg0 : wayOfMoving);
        }

        public override string ToString()
        {
            return $"{_name} est un {nameof(Dog)}. Il a {_age} ans et {_limbs} pattes et {(_isProtected ? "est protégé" : "n'est pas protégé")}";
        }
    }
}
