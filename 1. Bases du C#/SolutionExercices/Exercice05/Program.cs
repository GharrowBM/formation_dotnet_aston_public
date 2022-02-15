Console.Write("Veuilliez saisir un nombre : ");
double nombreA = Convert.ToDouble(Console.ReadLine());
Console.Write("Veuilliez saisir un nombre : ");
double nombreB = Convert.ToDouble(Console.ReadLine());
double resultat = nombreA + nombreB;
Console.WriteLine("La somme de ces deux nombres est : " + Math.Round(resultat, 2));