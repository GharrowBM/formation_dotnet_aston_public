double maxNote = 0;
double minNote = 20;
double moyNote = 0;

Console.WriteLine("--- Gestion des notes --- \n");
Console.WriteLine("Veuillez saisir 5 notes : \n");
for (int i = 1; i <= 5; i++)
{
    Console.Write("\t- Merci de saisir la note " + i + " (sur /20) : ");
    double noteTmp = Convert.ToDouble(Console.ReadLine());
    moyNote += noteTmp;
    if (noteTmp > maxNote)
        maxNote = noteTmp;
    if (noteTmp < minNote)
        minNote = noteTmp;
}

moyNote = moyNote / 5;

Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("la meilleure note est " + maxNote + "/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("la moins bonne note est " + minNote + "/20");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("La moyenne des notes est " + moyNote + "/20\n");