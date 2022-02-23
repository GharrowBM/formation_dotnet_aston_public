using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses.Enums
{
    [Flags]
    public enum FavoriteAnimals
    {
        None = 0,
        Cat = 1,
        Dog = 2,
        Hamster = 4,
        Chipmunk = 8,
        Fox = 16,
        Wolf = 32,
        Panther = 64,
        Lion = 128
    }
}
