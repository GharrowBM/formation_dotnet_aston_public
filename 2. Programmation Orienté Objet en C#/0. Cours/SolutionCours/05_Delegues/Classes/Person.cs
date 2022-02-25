using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Delegues.Classes
{
    internal class Person
    {
        public int AngerLevel { get; private set; }
        public string Name { get; private set; }

        public event EventHandler? Shout;
        public Person(string name)
        {
            Name = name;
        }

        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                Shout?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
