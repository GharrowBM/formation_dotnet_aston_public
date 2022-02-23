using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_BasesPOO;
internal class IHM
{
    public void Run()
    {
        TestTuple();
    }

    private void TestTuple()
    {
        //Tuple<int, int> SumAndProduct(int nbA, int nbB)
        //{
        //    int sum = nbA + nbB;
        //    int product = nbA * nbB;

        //    //return new Tuple<int, int>(sum, product);
        //    return Tuple.Create(sum, product);
        //}

        (int, int) SumAndProduct(int nbA, int nbB)
        {
            int sum = nbA + nbB;
            int product = nbA * nbB;

            //return new Tuple<int, int>(sum, product);
            return (sum, product);
        }

        int nombreA = 2;
        int nombreB = 10;

        //Tuple<int, int> myTuple = SumAndProduct(nombreA, nombreB);
        var (somme, produit) = SumAndProduct(nombreA, nombreB);

        Console.WriteLine($"{nombreA} + {nombreB} = {somme}");
        Console.WriteLine($"{nombreA} * {nombreB} = {produit}");
    }


    private void DemoSurchargeOperateurs()
    {
        Character matthieu = new("Matthieu", Gender.Homme);
        Character sandrine = new("Sandrine", Gender.Femme);
        Character chloee = new("Chloée", Gender.Femme);

        Character enfantA = matthieu * sandrine;
        Character enfantB = chloee * sandrine;

        matthieu.FavAnimals = FavoriteAnimals.Chien | FavoriteAnimals.Chat;

        Console.WriteLine("=== ADULTES ===");
        Console.WriteLine(matthieu);
        Console.WriteLine(sandrine);
        Console.WriteLine(chloee);

        Console.WriteLine("=== ENFANTS ===");
        Console.WriteLine(enfantA);
        Console.WriteLine(enfantB);
    }

    private void DemoBaseCSharp()
    {
        Person bernard = new Person();
        Person martin = new Person("Martin", "MATIN");
        Person martin2 = new("Martin", "MATIN");
        Person jane = new("Jane", "ROMERO", 34);
        Person elliot = new("Elliot", "ZUCKERBERG", new DateTime(1972, 05, 24));
        Person[] people = new Person[] { bernard, martin, jane };



        foreach (Person p in people)
        {
            //Console.WriteLine($"{p.FirstName} {p.LastName} a {p.Age} ans");
            Console.WriteLine(p);
        }

        Console.WriteLine($"bernard est égal à martin ? {(martin2.Equals(martin) ? "Oui" : "Non")}");

        //Console.WriteLine($"{elliot.FirstName} {elliot.LastName} a {elliot.AgeCalcule} ans");
    }

    private void DemoHeritage()
    {
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
                Dog dog => dog.NbOfCells switch
                {
                    > 9999 => "C'est un chien et il a beaucoup de cellules",
                    _ => "C'est un chien et il a peu de celulles"
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
            if (mammal is Dog) ((Dog)mammal).Chase();

        }

        for (int i = 0; i < 5; i++)
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
    }

    private void DemoGeneriques()
    {
        QueueCustom<string> maFile = new QueueCustom<string>(10);

        maFile.Add("Albert");
        maFile.Add("Bernard");
        maFile.Add("Chloé");
        maFile.Add("David");
        maFile.Add("Elliot");
        maFile.Add("Francis");

        foreach (var item in maFile)
        {
            if (item != null) Console.WriteLine(item);
        }
    }
    
    private void DemoExtensions()
    {
        // String de départ 

        string maString = "JE tAppE N'ImPoRTE CommENT eT je ME FICHE dE la SynTaxe !";
        List<int> maList = new List<int>();

        Random rng = new Random();

        for (int i = 0; i < 20; i++) maList.Add(rng.Next(31));

        // String voulue  => "Je tappe n'importe comment et je me fiche de la syntaxe !"

        string resultat = maString.ToCapitalize();
        List<int> listResult = maList.SortInferiorTo(15);

        Console.WriteLine($"Liste AVANT : {string.Join(", ", maList)}");
        Console.WriteLine($"Liste APRES : {string.Join(", ", listResult)}");
        Console.WriteLine("String AVANT : {0}", arg0: maString);
        Console.WriteLine("String APRES : {0}", arg0: resultat);

    }

    private void DemoDelegates()
    {
        Sale premiereVente = new Sale("Iphone X", 1299.99M);

        premiereVente.Promotion += EnvoieSMS;
        premiereVente.Promotion += EnvoieMail;

        premiereVente.Reduction(200);
    }

    private void DemoPredicate()
    {
        List<string> listBase = new List<string> { "Albert", "Bernard", "Alfred", "René", "Chloée" };

        List<string> listModif = listBase.SortMyList(person => person.StartsWith("Al"));

        Console.WriteLine($"Liste AVANT : {string.Join(", ", listBase)}");
        Console.WriteLine($"Liste APRES : {string.Join(", ", listModif)}");

    }

    private static void EnvoieSMS(decimal amount)
    {
        Console.WriteLine($"Une réduction a eu lieu : Nouveau prix : {amount:C2}");
    }

    private static void EnvoieMail(decimal amount)
    {
        Console.WriteLine($"Nouveau mail ! Réduction => Nouveau prix : {amount:C2}");

    }
}
