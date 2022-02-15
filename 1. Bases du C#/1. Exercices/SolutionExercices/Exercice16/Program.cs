double revenus = 0;
int nbAdulte = 0;
int nbEnfants = 0;
double nbParts;
double revenuImposable = 0;
double montantImpot = 0;

Console.WriteLine("--- Quelle sera le montant des mes impôts ? --- \n");
Console.Write("Entrez le montant net imposable du foyer (en Euros): ");
revenus = Convert.ToDouble(Console.ReadLine());
Console.Write("Entrez le nombre d'adulte du foyer : ");
nbAdulte = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez le nombre d'enfants du foyer : ");
nbEnfants = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("\n");

if (nbEnfants <= 2)
    nbParts = nbAdulte + nbEnfants * 0.5;
else
    nbParts = nbAdulte + nbEnfants - 1;

revenuImposable = revenus / nbParts;

if (revenuImposable >= 10085 && revenuImposable <= 25710)
    montantImpot = Math.Round((revenuImposable - 10084) * 0.11, 0);
else if (revenuImposable >= 25711 && revenuImposable <= 73516)
    montantImpot = Math.Round((revenuImposable - 25711) * 0.30 + (25711 - 10085) * 0.11, 0);
else if (revenuImposable >= 73517 && revenuImposable <= 158122)
    montantImpot = Math.Round((revenuImposable - 73516) * 0.41 + (73516 - 25710) * 0.30 + (25711 - 10085) * 0.11, 0);
else if (revenuImposable >= 158123)
    montantImpot = Math.Round((revenuImposable - 158122) * 0.45 + (158122 - 73516) * 0.41 + (73516 - 25710) * 0.30 + (25711 - 10085) * 0.11, 0);
montantImpot = montantImpot * nbParts;

Console.WriteLine($"Vous allez payer {montantImpot} Euros\n");