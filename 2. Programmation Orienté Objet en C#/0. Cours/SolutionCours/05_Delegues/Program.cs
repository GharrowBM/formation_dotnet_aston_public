using _05_Delegues.Classes;

namespace _05_Delegues
{
    public class Program
    {
        /*
         * Il est possible de passer des méthodes en paramètres de méthode en usant des délégués
         * Pour cela, il faut créer un nouveau délégué définissant une signature de méthodes pour les fonctions compatibles
         * 
         */

        public delegate void MyOwnDelegate(params string[] messages);
        public static void Main(string[] args)
        {
            /*
             * Ici, nous utiliseront les délégués dans le but de déclencher une méthode différente en fonction de notre choix
             * 
             * Contrairement à un déclenchement de deux fonctions différentes conditionnées par un IF..ELSE où l'on aurait à écrire manuellement les mêmes paramètres, on peut ici déclencher deux comportements différents à partir de la même série de string
             * 
             */

            Console.WriteLine("=== Delegates pour des fonctions callback ===\n");

            MyOwnDelegate customDel = null;

            int delChoice = -1;

            Console.WriteLine("0. Imprimez chaque string à la ligne");
            Console.WriteLine("1. Imprimez chaque caractère de chaque string");

            Console.Write("Choisissez votre callback : ");
            int.TryParse(Console.ReadLine(), out delChoice);

            if (delChoice == 0) customDel = PrintSomething;
            else if (delChoice == 1) customDel = PrintAllChars;

            customDel("Hello", "World", "In", "C# !");

            /*
             * Les délégués sont également souvent utilisés dans la programmation évènementielle afin d'assurer une communication entre deux classes, 
             * comme ici où l'on se sert de la méthode Poke pour déclencher des méthodes abonnées à l'évènement Shout de Person
             * 
             * Il est possible d'ajouter autant de méthodes que l'on veut à un évènement, via +=, ou d'en retirer via -= comme dans l'exemple ci-dessous :
             * 
             */

            Console.WriteLine();
            Console.WriteLine("=== Délégués en programmation évènementielle ===\n");

            Person johnSmith = new("John Smith");

            johnSmith.Shout += Person_AngerGlance;
            johnSmith.Shout += Person_Shout;

            for (int i = 0; i < 6; i++)
            {
                johnSmith.Poke();
                if (i == 2) johnSmith.Shout -= Person_AngerGlance;
            }
        }

        // Méthodes appellées par les délégués

        public static void PrintSomething(params string[] messages)
        {
            foreach(var item in messages) Console.WriteLine(item);
        }

        public static void PrintAllChars(params string[] strings)
        {
            foreach (var str in strings)
            {
                string spaces = "";
                foreach(char c in str)
                {
                    Console.WriteLine($"{spaces}{c}");
                    spaces += "  ";
                }
            }
        }
        public static void Person_Shout(object? sender, EventArgs e)
        {
            if (sender is null) return;
            Person p = (Person)sender;
            Console.WriteLine($"{p.Name} est en colère : {p.AngerLevel} !");
        }

        public static void Person_AngerGlance(object? sender, EventArgs e)
        {
            if (sender is null) return;
            Person p = (Person)sender;
            Console.WriteLine($"{p.Name} vous lance un regard mauvais !");
        }
    }
}