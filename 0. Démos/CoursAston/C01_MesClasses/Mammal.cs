using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public abstract class Mammal
    {
        private string _name;
        private int _nbOfCells;

        public int NbOfCells { get => _nbOfCells; }

        public Mammal(string name, int nbOfCells)
        {
            _name = name;
            _nbOfCells = nbOfCells;
        }

        public Mammal()
        {
            _name = "Unknown";
            _nbOfCells = new Random().Next();
        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{this.GetType().Name} dit : dsdqdsdsDQDQDQdqdQSDQdqSDQSDQdqdQ");
        }
    }
}
