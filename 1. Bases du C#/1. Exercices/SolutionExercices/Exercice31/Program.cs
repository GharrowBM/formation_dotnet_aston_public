int choice = 8;
int nbOfNotes = 0, sum = 0, maxNote = int.MinValue, minNote = int.MaxValue;

do
{
    Console.WriteLine("\n--- Gestion des notes avec menu ---");

    Console.WriteLine("\t1---Saisir les notes");
    Console.WriteLine("\t2---La plus grande note");
    Console.WriteLine("\t3---La plus petite note");
    Console.WriteLine("\t4---La moyenne des notes");
    Console.WriteLine("\t0---Quitter");

    Console.Write("\nFaites votre choix : ");

    if (int.TryParse(Console.ReadLine(), out choice))
    {

        Console.Clear();

        switch (choice)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----- Saisir les notes -----");
                Console.WriteLine("(999 pour stopper la saisie)");
                Console.ForegroundColor = ConsoleColor.Gray;

                int currentNote = 0;
                nbOfNotes = 0;
                sum = 0;
                maxNote = int.MinValue;
                minNote = int.MaxValue;

                do
                {
                    Console.Write($"Merci de saisir la note {nbOfNotes + 1} (sur /20) : ");
                    if (int.TryParse(Console.ReadLine().Trim(), out currentNote))
                    {
                        if (currentNote >= 0 && currentNote <= 20)
                        {
                            sum += currentNote;
                            if (currentNote > maxNote) maxNote = currentNote;
                            if (currentNote < minNote) minNote = currentNote;
                            nbOfNotes++;
                        }
                        else if (currentNote != 999)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erreur de saisie, la note est sur 20 !");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                } while (currentNote != 999);
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----- La plus grande note -----");
                Console.ForegroundColor = ConsoleColor.Gray;

                if (nbOfNotes == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nAucune note n'a encore été entrée !");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"La plus grande note est : {maxNote}/20");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----- La plus petite note -----");
                Console.ForegroundColor = ConsoleColor.Gray;

                if (nbOfNotes == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nAucune note n'a encore été entrée !");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"La plus grande note est : {minNote}/20");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("----- La moyenne des notes -----");
                Console.ForegroundColor = ConsoleColor.Gray;

                if (nbOfNotes == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nAucune note n'a encore été entrée !");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"La moyenne des notes est : {Math.Round((double)sum / (double)nbOfNotes, 1)}/20");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                break;
            case 0:
                break;
            default:
                Console.WriteLine("\nLa valeur entrée n'est pas un choix potentiel ! ");
                break;
        }
    }
} while (choice != 0);