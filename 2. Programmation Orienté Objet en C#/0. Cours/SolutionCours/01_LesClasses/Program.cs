using _01_LesClasses.Classes;

/*
 * Les classes servent de moule pour l'instanciation d'objets
 * 
 * Pour Créer un nouvel objet, on doit alors passer par le constructeur de la classe, que l'on peut définir nous-même
 * 
 * Un objet est une variable de type référence, on peut ainsi modifier ses champs depuis différents endroits du programme sans perdre ces modifications
 * 
 * Une classe a forcément un constructeur par défaut de par son héritage de la classe Object
 * 
 */

List<Person> people = new();

var johnSmith = new Person();
people.Add(johnSmith);
Person clarkKent = new Person("Clark", "Kent", 47251, true);
people.Add(clarkKent);
Person nathanDrake = new Person() { FirstName = "Nathan", LastName = "Drake", Age = 47, IsWorking = true };
people.Add(nathanDrake);
Person janeRomero = new("Jane", "Romero", 37, true);
people.Add((janeRomero));

Dog monChien = new("Rex", true);

Children monEnfant = new() { Name = "Robert", Age = 5, IsStudent = false };

PrintPeople(people);

/*
 * Une fois une classe créée, il est possible de modifier ses paramètres publiques via la notation objet.champ = valeur
 * 
 * Pour ses membres privés (encapsulés), on doit passer par des setters publiques tels que :
 * 
 */

johnSmith.LastName = "Cena";

PrintPeople(people);

// Méthodes raccourcis

static void PrintPeople(List<Person> people)
{
    people.ForEach(person =>
    {
        person.Afficher();
    });
}
