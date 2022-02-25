using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LesClasses.Classes
{
    /*
     * Ici, notre classe est abstraite, on ne pourra pas créer d'objet de cette classe. 
     * 
     * L'intérêt des classes abstraites viendra par la suite lors de l'apprentissage de l'héritage 
     * 
     */
    internal abstract class Animal
    {
        private string _name;
        private int _age;
        private bool _hasChip;

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public bool HasChip { get => _hasChip; set => _hasChip = value; }

        public Animal()
        {
            _name = "Miss Teigne";
            _age = 8;
            _hasChip = false;
        }
    }
}
