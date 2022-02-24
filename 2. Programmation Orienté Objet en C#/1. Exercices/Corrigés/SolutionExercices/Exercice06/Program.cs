using Exercice06.Classes;

List<string> liste = new List<string>();

liste.Add("Albert");
liste.Add("Elliot");
liste.Add("Angela");

string trouvee = liste.Rechercher(s => s.StartsWith("Al"));
string trouveAvecIndex = liste.Rechercher(s => liste[1] == s);

Console.WriteLine("Le premier élement trouvé dans la liste commençant par \"Al\" est " + trouvee);
Console.WriteLine("L'élément à l'index \"1\" est " + trouveAvecIndex);