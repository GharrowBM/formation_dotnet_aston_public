Console.WriteLine("--- Le nombre est-il divisible par...? ---\n");
Console.Write("Entrez un chiffre/nombre entier : ");
int nombreSaisi = int.Parse(Console.ReadLine());
Console.Write("Entrez le chiffre/nombre diviseur : ");
int nombreDiviseur = int.Parse(Console.ReadLine());

if(nombreSaisi % nombreDiviseur == 0)
{
    Console.WriteLine($"Le  est divisible par " + nombreDiviseur);
}
else
{
    Console.WriteLine($"Le chiffre/nombre n'est pas divisible par " + nombreDiviseur);
}

//Console.WriteLine("--- Le nombre est-il divisible par...? ---\n");
//Console.Write("Entrez un chiffre/nombre entier : ");
//int nombreSaisi = int.Parse(Console.ReadLine());
//Console.Write("Entrez le chiffre/nombre diviseur : ");
//int nombreDiviseur = int.Parse(Console.ReadLine());

//if (nombreSaisi % nombreDiviseur == 0)
//{
//    Console.WriteLine($"Le {(nombreSaisi >= 10 ? "nombre" : "chiffre")} est divisible par {nombreDiviseur}");
//}
//else
//{
//    Console.WriteLine($"Le {(nombreSaisi >= 10 ? "nombre" : "chiffre")} n'est pas divisible par {nombreDiviseur}");
//}