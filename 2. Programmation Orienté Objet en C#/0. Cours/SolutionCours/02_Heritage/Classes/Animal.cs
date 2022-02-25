using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Heritage.Classes
{
    /*
     * Ici, notre classe est abstraite, on ne pourra pas créer d'objet de cette classe. 
     * 
     * On peut créer des classes qui héritent de cette dernière et qui du coup possèderont ses champs non privés de base lors de leur création
     * 
     */
    internal abstract class Animal
    {
        protected string _name;
        protected int _age;
        protected bool _isProtected;


        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        protected bool IsProtected { get => _isProtected; set => _isProtected = value; }

        public Animal()
        {
            _name = "Animal Inconnu";
            _age = 3;
            _isProtected = true;
        }

        public Animal(string name, int age, bool isProtected)
        {
            _name = name;
            _age = age;
            _isProtected = isProtected;
        }

        /*
         * On peut créer une méthode virtuelle qui est destinée à la redéfinition, 
         * 
         * c'est à dire la modification dans la classe enfant
         * 
         */

        public virtual void MakeSound()
        {
            Console.WriteLine($"{_name} fait un son !");
        }

        /*
         * On peut créer une méthode abstraite qui forcera l'utilisateur à respecter sa signature lors de son implementation, 
         * 
         * à la façon d'une interface
         * 
         */

        public abstract void Move(string wayOfMoving);
    }
}
