Console.WriteLine("--- Calcul de la longueur de l'hypothnuse ---");
Console.Write("Entrez la longueur du premier côté (en cm) : ");
double premierCote = Convert.ToDouble(Console.ReadLine());
Console.Write("Entrez la longueur du deuxième côté (en cm) : ");
double deuxiemeCote = Convert.ToDouble(Console.ReadLine());
double hypothenuse = Math.Sqrt(Math.Pow(premierCote, 2) + Math.Pow(deuxiemeCote, 2));
Console.WriteLine($"La longueur de l'hypothénuse est : {Math.Round(hypothenuse, 2)} cm");