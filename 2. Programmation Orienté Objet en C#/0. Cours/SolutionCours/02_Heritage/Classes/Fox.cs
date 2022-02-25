using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Heritage.Classes
{
    internal class Fox : Mammal
    {
        private List<string> _trackList;

        public Fox(string name, int age, bool isProtected, int limbs) : base(name, age, isProtected, limbs)
        {
            _trackList = new List<string>()
            {
                "What does the Fox Says !?",
                "IMMA FIRIN MAH'LAZER",
                "DO WHOOP WOOP WOOP DOWAAA"
            };
        }

        /*
         * Au sein d'une classe, il est possible d'avoir recourt à du Polymorphisme
         * 
         * Le Polymorphisme peut consister en une utilisation d'un même nom de méthode 
         * avec des paramètres différents pour effectuer une logique métier différente
         * 
         */

        public string Sing(int index)
        {
            return _trackList[index];
        }

        public string Sing(string songName = "What does")
        {
            return _trackList.SingleOrDefault(str => str.StartsWith(songName));
        }

        /*
         * Une autre façon de se servir du polymorphisme est en redéfinissant une méthode d'une classe hérité, via l'utilisation du mot clé "override"
         * 
         * Cela permet par exemple de modifier le son que fait un animal en fonction de son type
         * 
         */

        public override void MakeSound()
        {
            Console.WriteLine($"What does the fox says !?");
        }

        /*
         * Une méthode abstraite doit être implémentée pour être utilisée, en respéctannt la signature de celle des parents 
         * 
         * (à la façon d'une interface)
         * 
         */

        public override void Move(string wayOfMoving)
        {
            Console.WriteLine("Le renard danse dans la forêt. Pour cela, il se sert de : {0}",
                arg0: wayOfMoving);
        }

        /*
         * Une utilisation commune de l'override est pour redéfinir la méthode ToString de la super-classe Object, 
         * permettant d'afficher les champs d'un objet de façon plus lisible pour l'utilisateur.
         * 
         */

        public override string ToString()
        {
            return $"{_name} est un {nameof(Fox)}. Il a {_age} ans et {_limbs} pattes et {(_isProtected ? "est protégé" : "n'est pas protégé")}";
        }
    }
}
