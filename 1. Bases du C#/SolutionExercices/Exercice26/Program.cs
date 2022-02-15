double nbhabitant = 96809;
int date = 2015;
int nbAnnee = 0;

while(nbhabitant < 120000)
{
    nbhabitant = nbhabitant + nbhabitant * 0.0089;
    date++;
    nbAnnee++;
}

Console.WriteLine("--- Accroissement de population --- \n");
Console.WriteLine("Il faudra " + nbAnnee + " ans, nous serons en " + date);
Console.WriteLine("Il y aura " + Math.Round(nbhabitant, 0) + " habitants en " + date + "\n");