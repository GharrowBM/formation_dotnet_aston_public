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
        Rien = 0,
        Chat = 1,
        Chien = 2,
        Hamster = 4,
        Chipmunk = 8,
        Renard = 16,
        Loup = 32,
        Panthère = 64,
        Lion = 128
    }
}
