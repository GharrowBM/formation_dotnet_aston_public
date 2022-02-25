using _07_Extras.Classes;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

/*
 * Les classes partielles sont des classes dont le contenu peut être séparé en plusieurs fichiers, et qui seront rassemblés lors de la compilation
 * 
 * Ces classes sont principalement utilisées dans la construction des applications à interfaces graphiques, telle une application WPF
 * 
 * La partie graphique .XAML.CS sera la partial classe de la partie .CS et ces deux fichiers seront rassemblés à la compilation pour fonctionner ensemble 
 * 
 */

Console.WriteLine("=== Les Classes partielles ===\n");

Product maPoire = new("Poire", "Fruit plutôt sucré quand bien mûr", 0.99M, 20);
Product maPomme = new("Pomme", "Fruit parfois empoisonné", 0.80M, 25);
maPomme.SayTaxes("FR");

Client premierClient = new("John SMITH", "0123456789", "john.smith@mail.com");

Console.WriteLine();
Sale premièreVente = new(premierClient, new List<Product> { maPoire, maPomme});

/*
 * Une classe imbriquées est une classe comprise dans une autre classe, ce qui fait que pour y accéder, il faut se servir de la syntaxe ClasseBase.ClasseImbriquée, 
 * comme dans l'exemple ci-dessous
 * 
 */

Console.WriteLine();
Console.WriteLine("=== Les Classes imbriquées ===\n");

Product monGateau = new("Fraisier", "Gâteau aux fraises appréciés des femmes enceintes", 18.99M, 4, new Product.Ingredient[] { new Product.Ingredient("Fraises", "Fruit rouge pour femmes enceintes"), new Product.Ingredient("Crème chantilly", "Attention aux carries")});

Sale secondeVente = new(premierClient, new List<Product> { maPoire, maPomme, monGateau });

secondeVente.PrintSale();

/*
 * Les structures sont des types valeurs, ils ne sont pas stockés dans le HEAP, et fonctionne comme les autres Structures tel Int32, Decimal, etc...
 * 
 * Leur utilisation est principalement dans un soucis d'optimisation de la mémoire
 * 
 */

Console.WriteLine();
Console.WriteLine("=== Les Structures ===\n");

Coordinate pointA = new() { X = 4.87, Y = 75.41};
Coordinate pointB = new() { X = 10, Y = 10};
Coordinate pointC = pointA with { Y = -17.54 };

Console.WriteLine($"Distance du point A {pointA} par rapport à l'origine : {pointA.GetDistanceFromOrigin():N2}");
Console.WriteLine($"Distance du point B {pointB} par rapport à l'origine : {pointB.GetDistanceFromOrigin():N2}");
Console.WriteLine($"Distance du point C {pointC} par rapport à l'origine : {pointC.GetDistanceFromOrigin():N2}");

Console.WriteLine();
Console.WriteLine("=== La Surcharge des Opérateurs ===\n");

Person albert = new("Albert", 0);
Person aretha = new("Aretha", 1);
Person christine = new("Christine", 1);

Person enfantA = albert + aretha;
Person enfantB = aretha + christine;

Person[] persons = { albert, aretha, christine, enfantA, enfantB};

for (int i = 0; i < persons.Length; i++)
{
    Console.WriteLine(persons[i]);
}

/*
 * Les indexeurs servent à permettre la manipulation d'une série d'element via la notation à crochets, 
 * comme dans un tableau
 * 
 */

Console.WriteLine();
Console.WriteLine("=== Les Indexeurs ===\n");

AlphaList alphaList = new AlphaList("Alpha", "Beta", "Gamma", "Delta");

Console.WriteLine("AVANT : ");
for (int i = 0; i < alphaList.Count; i++) Console.Write($"{alphaList[i]} ");
Console.WriteLine();

alphaList[2] = "Omega";

Console.WriteLine("APRES : ");
for (int i = 0; i < alphaList.Count; i++) Console.Write($"{alphaList[i]} ");


/*
 * L'extension de méthode est la dynamique de programmation utilisée par Linq pour permettre des méthodes supplémentaires sur les élements de type collection comme des listes 
 * 
 * Ces extensions servent à rajouter des méthodes à un type précis, comme par ici pour mettre en Capital une string, ce dans un soucis d'étendre les fonctionnalités de la classe String
 * 
 */

Console.WriteLine();
Console.WriteLine("=== Extensions de Méthodes ===\n");

string message = "J'ÉcriS uN MessAGE n'Importe COMMENT !";

Console.WriteLine(message.ToCapitalize());


