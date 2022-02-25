using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LesClasses.Classes
{
    internal class Dog
    {
        public string Name { get; private set; }
        public bool IsProtected { get; private set; }

        public Dog(string name, bool isProtected)
        {
            Name = name;
            IsProtected = isProtected;
        }
    }
}
