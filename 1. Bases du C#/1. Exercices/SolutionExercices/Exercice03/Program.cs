Console.Write("Veuilliez saisir votre nom : ");
string? nom = Console.ReadLine();
Console.WriteLine("Veuilliez saisir votre prénom : ");
string? prenom = Console.ReadLine();
string nomComplet = prenom + " " + nom;
Console.WriteLine("Bonjour " + nomComplet);