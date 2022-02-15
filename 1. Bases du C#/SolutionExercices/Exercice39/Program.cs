int choice = 4;
string[] participants = new string[] { "Marc", "Albert", "Brigitte", "Marcel", "Pauline", "Angela", "Elliot", "Tyrel" };
string[] gagnants = new string[participants.Length];

do
{
    Console.WriteLine("\n--- Le grand tirage au sort ---");

    Console.WriteLine("\t1---Effectuer un tirage");
    Console.WriteLine("\t2---Voir la liste des personnes déjà tirées");
    Console.WriteLine("\t3---Voir la liste des personnes restantes");
    Console.WriteLine("\t0---Quitter");

    Console.Write("Faites votre choix : ");

    if (int.TryParse(Console.ReadLine(), out choice))
    {
        switch (choice)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- Nouveau tirage ---");
                Console.ForegroundColor = ConsoleColor.Gray;

                Array.Sort(gagnants);
                Array.Sort(participants);
                Array.Reverse(participants);


                int randomNumber;

                do
                {
                    randomNumber = new Random().Next(participants.Length);
                } while (participants[randomNumber] == "" && participants.Length > 0);

                Console.WriteLine($"Le grand gagnant est {participants[randomNumber]} !");
                gagnants[randomNumber] = participants[randomNumber];
                participants[randomNumber] = "";

                Array.Sort(gagnants);
                Array.Sort(participants);
                Array.Reverse(participants);
                Array.Reverse(gagnants);

                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- Liste des gagnants ---");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("");

                foreach (string gagnant in gagnants)
                {
                    if (!string.IsNullOrEmpty(gagnant))
                    {
                        int currentIndex = Array.IndexOf(gagnants, gagnant);

                        for (int i = 0; i < currentIndex; i++)
                        {
                            Console.Write(" ");
                        }

                        Console.WriteLine(gagnant);
                    }
                }

                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- Participants restants ---");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("");

                foreach (string participant in participants)
                {
                    if (!string.IsNullOrEmpty(participant))
                    {
                        int currentIndex = Array.IndexOf(participants, participant);

                        for (int i = 0; i < currentIndex; i++)
                        {
                            Console.Write(" ");
                        }

                        Console.WriteLine(participant);
                    }
                }

                break;
            default:
                break;

        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Erreur de saisie !");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
} while (choice != 0);