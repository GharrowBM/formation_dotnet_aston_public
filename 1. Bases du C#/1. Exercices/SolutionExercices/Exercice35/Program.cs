Console.WriteLine("=== Gestion des Contacts ===");
Console.Write("Merci de saisir le nombre de contacts : ");
int nbOfContacts;
if (int.TryParse(Console.ReadLine(), out nbOfContacts))
{
    string[] contacts = new string[nbOfContacts];

    int choice = 4;

    do
    {
        Console.WriteLine("\n--- Ma liste de contacts ---");
        Console.WriteLine("\t1---Saisir des contacts");
        Console.WriteLine("\t2---Afficher les contacts");
        Console.WriteLine("\t0---Quitter");

        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("--- Saisir les contacts ---");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    for (int i = 0; i < nbOfContacts; i++)
                    {
                        Console.Write($"Nom et prénom du contact N°{i+1} : ");
                        contacts[i] = Console.ReadLine();
                    }

                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("--- Affichage des contacts ---");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    for (int i = 0; i < nbOfContacts; i++)
                    {
                        Console.WriteLine($"Contact N°{i+1} : {contacts[i]}");
                    }

                    break;
                default:
                    break;

            }


        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("La valeur entrée n'est pas correcte !");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    } while (choice != 0);
}