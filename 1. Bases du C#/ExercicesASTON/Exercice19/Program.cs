double revenus;
int nbAdulte;
int nbEnfants;
double nbParts;
double revenuImposable;
double montantImpot;

Console.WriteLine("--- Quelle sera le montant des mes impôts ? --- \n");
Console.Write("Entrez le montant net imposable du foyer (en Euros): ");
revenus = Convert.ToDouble(Console.ReadLine());
Console.Write("Entrez le nombre d'adulte du foyer : ");
nbAdulte = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez le nombre d'enfants du foyer : ");
nbEnfants = Convert.ToInt32(Console.ReadLine());
//nbEnfants = nbEnfants > 2 ? nbEnfants - 1 : nbEnfants / 2;
Console.WriteLine("\n");

if (nbEnfants > 2)
    nbParts = nbAdulte + nbEnfants - 1;
else
    nbParts = nbAdulte + nbEnfants * 0.5;

//nbParts = nbEnfants > 2 ? nbAdulte + nbEnfants - 1 : nbAdulte + nbEnfants * 0.5;

revenuImposable = revenus / nbParts;
montantImpot = 0;

switch (revenuImposable)
{
    case var expression when revenuImposable >= 10065 && revenuImposable <= 25659:
        montantImpot = Math.Round((revenuImposable - 10064) * 0.11, 0); break;
    case var expression when revenuImposable >= 25660 && revenuImposable <= 73369:
        montantImpot = Math.Round((revenuImposable - 25659) * 0.3 + 1715.34, 0); break;
    case var expression when revenuImposable >= 73370 && revenuImposable <= 157806:
        montantImpot = Math.Round((revenuImposable - 73369) * 0.41 + 1715.34 + 14312.7, 0); break;
    case var expression when (revenuImposable >= 157807):
        montantImpot = Math.Round((revenuImposable - 157806) * 0.45 + 1715.34 + 14312.7 + 34618.8, 0); break;
}

montantImpot = montantImpot * nbParts;

Console.WriteLine($"Vous allez payer {montantImpot.ToString("N0")} Euros\n");

// Version DECIMAL

//int nbAdulte;
//int nbEnfants;
//decimal revenus;
//decimal nbParts;
//decimal revenuImposable;
//decimal montantImpot;

//Console.WriteLine("--- Quelle sera le montant des mes impôts ? --- \n");
//Console.Write("Entrez le montant net imposable du foyer (en Euros): ");
//revenus = Convert.ToDecimal(Console.ReadLine());
//Console.Write("Entrez le nombre d'adulte du foyer : ");
//nbAdulte = Convert.ToInt32(Console.ReadLine());
//Console.Write("Entrez le nombre d'enfants du foyer : ");
//nbEnfants = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("\n");

//if (nbEnfants > 2)
//    nbParts = nbAdulte + nbEnfants - 1;
//else
//    nbParts = nbAdulte + nbEnfants * 0.5M;

//revenuImposable = Decimal.Divide(revenus, nbParts);
//montantImpot = 0;

//switch (revenuImposable)
//{
//    case var expression when revenuImposable >= 10065 && revenuImposable <= 25659:
//        montantImpot = Math.Round((revenuImposable - 10064M) * 0.11M, 0); break;
//    case var expression when revenuImposable >= 25660 && revenuImposable <= 73369:
//        montantImpot = Math.Round((revenuImposable - 25659M) * 0.3M + 1715.34M, 0); break;
//    case var expression when revenuImposable >= 73370 && revenuImposable <= 157806:
//        montantImpot = Math.Round((revenuImposable - 73369M) * 0.41M + 1715.34M + 14312.7M, 0); break;
//    case var expression when (revenuImposable >= 157807):
//        montantImpot = Math.Round((revenuImposable - 157806M) * 0.45M + 1715.34M + 14312.7M + 34618.8M, 0); break;
//}

//montantImpot = montantImpot * nbParts;

//Console.WriteLine($"Vous allez payer {montantImpot.ToString("N0")} Euros\n");