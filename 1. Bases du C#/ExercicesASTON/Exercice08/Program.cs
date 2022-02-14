Console.Write("Entrez le prix HT de l'objet (en Euros) : ");
double prixHT = Convert.ToDouble(Console.ReadLine());
Console.Write("Entrez le taux de la TVA (en %) : ");
double tauxTVA = Convert.ToInt32(Console.ReadLine());
double montantTVA = prixHT * (tauxTVA / 100);
Console.WriteLine($"Le montant de la T.V.A. est de {Math.Round(montantTVA, 2)} Euros");
double prixTTC = prixHT + montantTVA;
Console.WriteLine($"Le prix TTC de l'objet est de {Math.Round(prixTTC, 2)} Euros");