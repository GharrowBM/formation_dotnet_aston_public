Console.WriteLine("--- Est pair...? Est impair...? ---");
Console.Write("Combien de nombres contiendra le tableau ? : ");
int nbOfValues = Convert.ToInt32(Console.ReadLine());
int[] table = new int[nbOfValues];
Console.WriteLine("Affectation automatique des valeurs...");

for (int i = 0; i < nbOfValues; i++)
{
    table[i] = new Random().Next(101);
}

Console.WriteLine("Vérification des valeurs du tableau : ");

for (int i = 0; i < nbOfValues; i++)
{
    Console.WriteLine($"Le nombre {table[i]} est {(table[i] % 2 == 0 ? "pair" : "impair")}");
}