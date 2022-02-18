Console.WriteLine("--- Question à choix multiple ---");

Console.WriteLine("Quelle est l'instruction (en C#) qui permet de sortir d'une boucle ?" +
    "\n\t A) quit" +
    "\n\t B) continue" +
    "\n\t C) break" +
    "\n\t D) exit");

do
{
    Console.Write("\nEntrez votre réponse : ");

    if (Console.ReadLine().ToUpper() != "C")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Inccorect !");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("Un nouvel essai ? oui / non : ");
        string choice;
        do
        {
            choice = Console.ReadLine().ToUpper();
        } while (choice != "NON" && choice != "OUI");
        if (choice == "NON") break;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nBravo ! C'est la bonne réponse");
        Console.ForegroundColor = ConsoleColor.Gray;
        break;
    }
} while (true);