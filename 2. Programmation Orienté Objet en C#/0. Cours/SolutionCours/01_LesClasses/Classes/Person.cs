using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LesClasses.Classes
{
    /*
 * Ici, notre classe est scelléee, on ne pourra pas hériter de cette classe. 
 * 
 * L'intérêt des classes scellée vient de leur protection face à l'héritage, ce qui empêche d'autres classes d'accéder à leurs
 * 
 */
    internal sealed class Person
    {

        // Les champs suivants sont privés, ils ne sont accessibles qu'a un objet construit à partir de cette classe
        private string _firstName;
        private string _lastName;
        private int _age;
        private bool _isWorking;


        /*
         * Ici, on déclare des propriétés, qui sont publiques et permettent de modifier les champs privés depuis l'extérieur de l'objet
         * 
         * Notez qu'il est possible d'ajouter de la logique métier à ces getters et setters afin de constrôler les modifications
         * 
         */

        public string FullName
        {
            get
            {
                return _firstName + " " + _lastName;
            }
        }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int Age { get => _age; set => _age = value; }
        public bool IsWorking { get => _isWorking; set => _isWorking = value; }

        /*
         * Les constructeurs 
         * 
         * Une classe peut avoir plusieurs constructeurs, et possède par défaut un constructeur vierge de par son rapport avec la super-classe Object
         * 
         * Ces constructeurs peuvent accepter autant de paramètres que nécessaire pour remplir les champs privés d'un objet, 
         * 
         * ou n'en prendre aucun pour leur donner une valeur par défaut comme dans les exemples suivants :
         * 
         */

        // Constructeurs acceptant des paramètres

        public Person(string firstName, string lastName, int age, bool isWorking)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _isWorking = isWorking;
        }

        // Constructeur par défaut 

        public Person()
        {
            _firstName = "John";
            _lastName = "SMITH";
            _age = 28;
            _isWorking = true;
        }

        public void Afficher()
        {
            Console.WriteLine($"{FullName} a {_age} ans et {(_isWorking ? "travaille" : "galère avec Pôle Emploi")}");
        }
    }
}
