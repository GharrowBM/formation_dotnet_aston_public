Console.Write("Veuilliez saisir votre nom : ");
string? nom = Console.ReadLine();
Console.WriteLine("Veuilliez saisir votre prénom : ");
string? prenom = Console.ReadLine();
string nomComplet = prenom + " " + nom;
Console.Write("Veuilliez saisir votre âge : ");
int age = Convert.ToInt32(Console.ReadLine());

/* 
 * OU
 *  int age = int.Parse(Console.ReadLine());
 * OU
 *  int age = 0;
 *  int.TryParse(Console.ReadLine(), out age);
 */  

Console.WriteLine("Bonjour " + nomComplet + ", vous avez " + age + "ans");