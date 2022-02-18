using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public class Dog : Mammal
    {
        private string _couleurCollier;


        public Dog(string name, int nbOfCells, string couleurCollier) : this(name, nbOfCells)
        {
            _couleurCollier = couleurCollier;
        }

        public Dog(string name) : base()
        {

        }

        public Dog(string name, int nbOfCells) : base(name, nbOfCells)
        {
        }

        public void Chase()
        {
            Console.WriteLine($"{this.GetType().Name} chasse quelque chose");
        }

        public void Chase(string something)
        {
            Console.WriteLine($"{this.GetType().Name} chasse : {something}");
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{this.GetType().Name} dit : WOOF WOOF et hérite de {this.GetType().BaseType.Name}");
        }
    }
}
