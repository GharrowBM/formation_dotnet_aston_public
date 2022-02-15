Console.WriteLine("--- Où est passé mon numéro ? ---");
Console.WriteLine("Affectation des valeurs...");

int firstNumber = new Random().Next(51);
int[] table = new int[10];
table[0] = firstNumber;

for (int i = 1; i < table.Length; i++)
{
    table[i] = new Random().Next(51);
}

Console.WriteLine("Affichage avant sorting : ");
for (int i = 0; i < table.Length; i++)
{
    for (int j = 0; j < i; j++)
    {
        Console.Write("\t");
    }

    Console.WriteLine(table[i]);
}

Array.Sort(table);

Console.WriteLine("Affichage après sorting : ");
for (int i = 0; i < table.Length; i++)
{
    for (int j = 0; j < i; j++)
    {
        Console.Write("\t");
    }

    Console.WriteLine(table[i]);
}

Console.WriteLine($"Le nombre {firstNumber} se trouvait en 1ère position avant triage, puis en {Array.IndexOf(table, firstNumber) + 1} position après triage.");