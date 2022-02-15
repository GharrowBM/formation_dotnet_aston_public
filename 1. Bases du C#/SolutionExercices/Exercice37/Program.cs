string[] mois = new string[] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Decembre" };

Console.WriteLine("--- Enumération du tableau avec un foreach : ");

foreach (string moi in mois)
{
    int index = Array.IndexOf(mois, moi);
    for (int i = 0; i < index; i++)
    {
        Console.Write("\t");
    }

    Console.WriteLine(moi);
}