using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public class Cat : Mammal, IMovable, IAnimal
    {
        public Cat(string name, int nbOfCells) : base(name, nbOfCells)
        {
        }


        public override void MakeSound()
        {
            Console.WriteLine($"{this.GetType().Name} dit : MEEEEEEE");
        }

        public void MoveBackward(double distance)
        {
            Console.WriteLine($"L'humain avance de {distance:N0} mètres avec ses pattes.");

        }

        public void MoveForward(double distance)
        {
            Console.WriteLine($"L'humain recule de {distance:N0} mètres avec ses pattes.");

        }
    }
}
