Console.WriteLine("--- LA lettre est-elle une voyelle ?\n");
Console.Write("Entrez une lettre : ");
string lettre = Console.ReadLine();
string lettreMajuscule = lettre.ToUpper();

if (lettreMajuscule == "A" || lettreMajuscule == "E" || lettreMajuscule == "I" || lettreMajuscule == "O" || lettreMajuscule == "U" || lettreMajuscule == "Y")
{
    Console.WriteLine("Cette lettre est une voyelle !");
}
else
{
    Console.WriteLine("Cette lettre est une consomne !");
}