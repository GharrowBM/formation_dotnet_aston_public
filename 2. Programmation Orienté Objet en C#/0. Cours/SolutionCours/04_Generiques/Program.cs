using _04_Generiques.Classes;

CustomQueue<string> custom = new(10);

const string TO_ADD_AND_REMOVE = "Toto";

Console.WriteLine("=== Ajout de 20 valeurs ===\n");

for (int i = 0; i < 20; i++)
{
    string retrieved = custom.Add(TO_ADD_AND_REMOVE);
    if (retrieved is not null)
    {
        Console.WriteLine($"{retrieved} a été ajouté à la pile !");
    }
}

Console.WriteLine();
Console.WriteLine("=== Retrait de 20 valeurs ===\n");

for (int i = 0; i < 20; i++)
{
    string retrieved = custom.Remove();
    if (retrieved is not null)
    {
        Console.WriteLine($"{retrieved} a été retiré de la pile !");
    }
}

Console.WriteLine();
Console.WriteLine("=== First In, First Out ===\n");


Console.WriteLine($"{custom.Add("Toto")} a été ajouté à la file !");
Console.WriteLine($"{custom.Add("Tata")} a été ajouté à la file !");
Console.WriteLine($"Element N°1 dans la file : {custom[1]}");
Console.WriteLine($"{custom.Remove()} a été retiré de la file !");
Console.WriteLine($"{custom.Add("Tutu")} a été ajouté à la file !");
Console.WriteLine($"{custom.Remove()} a été retiré de la file !");
Console.WriteLine($"{custom.Add("Titi")} a été ajouté à la file !");
Console.WriteLine($"{custom.Remove()} a été retiré de la file !");
