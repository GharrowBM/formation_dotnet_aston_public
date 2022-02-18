
using MesClasses;

#region Pre Héritage

//Person bernard = new Person();
//Person martin = new Person("Martin", "MATIN");
//Person martin2 = new("Martin", "MATIN");
//Person jane = new("Jane", "ROMERO", 34);
//Person elliot = new("Elliot", "ZUCKERBERG", new DateTime(1972, 05, 24));
//Person[] people = new Person[] { bernard, martin, jane };



//foreach (Person p in people)
//{
//    //Console.WriteLine($"{p.FirstName} {p.LastName} a {p.Age} ans");
//    Console.WriteLine(p);
//}

//Console.WriteLine($"bernard est égal à martin ? {(martin2.Equals(martin) ? "Oui" : "Non")}");

////Console.WriteLine($"{elliot.FirstName} {elliot.LastName} a {elliot.AgeCalcule} ans");

#endregion

#region Démo Héritage

Person maPersonne = new Person();
Dog monChien = new("Rex", 499);
Cat monChat = new("Grosminet", 666);
Dog monChien2 = new("Rexo");
Dog monChienACollier = new("Falco", 595551651, "Rouge");


Mammal[] mammals = new Mammal[] { monChien, monChat, monChien2 };
IMovable[] movables = { monChat, maPersonne };


foreach (var movable in movables) movable.MoveForward(455.57);

string message = string.Empty;

foreach (var mammal in mammals)
{
    // Syntaxe C# 8.0
    message = mammal switch
    {
        Dog dog when dog.NbOfCells > 9999 => "C'est un chien et il a beaucoup de cellules",
        Dog => "C'est un chien et il a peu de cellules",
        Cat => "C'est un chat",
        _ => "On ne sait pas ce que c'est"
    };

    // Syntaxe C# 9.0 Version longue
    message = mammal switch
    {
        Dog dog => dog.NbOfCells switch {
            > 9999 => "C'est un chien et il a beaucoup de cellules",
            _ =>  "C'est un chien et il a peu de celulles"
        },
        Cat => "C'est un chat",
        _ => "On ne sait pas ce que c'est"
    };

    // Syntaxe C# 9.0 Version courte
    message = mammal switch
    {
        Dog { NbOfCells: > 9999 } => "C'est un chien et il a beaucoup de cellules",
        Dog => "C'est un chien et il a peu de cellules",
        Cat => "C'est un chat",
        _ => "On ne sait pas ce que c'est"
    };

    Console.WriteLine(message);

    mammal.MakeSound();
    if (mammal is Dog) ((Dog) mammal).Chase();
    
}

for(int i =0; i < 5; i++)
{
    string prenom = GenerateurDePrenom.Generer(0);
    string prenom2 = GenerateurPrenomNonStatique.Instance.Generer(1);

    Console.WriteLine($"Le prénom généré aléatoirement est : {prenom}");
    Console.WriteLine($"Le second prénom généré aléatoirement est : {prenom2}");

}

Console.WriteLine(GenerateurDePrenom.RetournerType(monChat));
Console.WriteLine(GenerateurDePrenom.RetournerType(maPersonne));


/*
 * L'inverse n'est pas possible 
 * 
 * Dog[] dogs = new Dog[] { monChien, monChien2, monChat };
 * 
 */

//Console.Write("Mon chat dit : ");
//monChat.MakeSound();

//Console.Write("Mon chien dit : ");
//monChien.MakeSound();

Console.WriteLine();

monChien.Chase();
monChien.Chase("Une taupe");

#endregion