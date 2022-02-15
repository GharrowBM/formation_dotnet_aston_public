Console.WriteLine("--- Dans quelle catégorie mon enfant est-il...? ---\n");
Console.Write("Entrez l'âge de votre enfant : ");
int ageEnfant = int.Parse(Console.ReadLine());

if (ageEnfant < 3)
{
    Console.WriteLine("Votre enfant est trop jeune !");
}
else if (ageEnfant >= 3 && ageEnfant <7)
{
    Console.WriteLine("Votre enfant est dans la catégorie \"Baby\" !");
}
else if (ageEnfant >= 7 && ageEnfant < 9)
{
    Console.WriteLine("Votre enfant est dans la catégorie \"Poussin\" !");
}
else if (ageEnfant >= 9 && ageEnfant < 11)
{
    Console.WriteLine("Votre enfant est dans la catégorie \"Pupille\" !");
}
else if (ageEnfant >= 11 && ageEnfant < 13)
{
    Console.WriteLine("Votre enfant est dans la catégorie \"Minime\" !");
}
else if (ageEnfant >= 13 && ageEnfant < 18)
{
    Console.WriteLine("Votre enfant est dans la catégorie \"Cadet\" !");
}
else 
{
    Console.WriteLine("Votre enfant est trop vieux !");
}