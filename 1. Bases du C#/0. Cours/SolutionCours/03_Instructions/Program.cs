using System.Text;

Console.OutputEncoding = Encoding.UTF8;

/*
 * Les Instructions servent à contrôler le flux du programme, il en existe de deux types majeurs : 
 * 
 * Les instructions de contrôle, qui servent à réaliser une partie ou une autre d'un programme en fonction de vérifications
 * Parmi ces instructions, on trouve : IF / ELSE IF / ELSE / SWITCH
 * 
 * Les instructions d'itération, qui servent à reproduire des parties du programme en fonction de vérifications
 * Parmi ces instructions, on trouve : DO...WHILE / WHILE / FOR
 * 
 */

/*
 * Le IF / ELSE IF / ELSE  est une instruction permettant de réaliser une partie du programme en fonction d'une condition spéficiée,
 * 
 * On peut avoir autant de ELSE IF que l'on veut, mais attention à les mettre dans le bon ordre, au risque de rencontrer les conditions de la vérification avant l'atteinte d'un ELSE IF moins généraliste
 * 
 */

Console.WriteLine("=== LES INSTRUCTIONS CONDITIONNELLES ===\n");

Console.WriteLine("IF / ELSE IF / ELSE");

int intA = 15;

Console.WriteLine("\nintA vaut 15 ?");

if (intA == 15)
{
    Console.WriteLine("intA vaut 15");
}

Console.WriteLine("\nintA vaut 5 ? Sinon...");

if (intA == 5)
{
    Console.WriteLine("intA vaut 5");
}
else
{
    Console.WriteLine("Sinon, intA peut avoir pour valeur n'importe quoi...");
}

Console.WriteLine("\nintA vaut 5 ? Ou 20 ? Ou 3 ? Sinon...");

if (intA == 5)
{
    Console.WriteLine("intA vaut 5");
}
else if (intA == 20)
{
    Console.WriteLine("intA vaut 20");
}
else if (intA == 3)
{
    Console.WriteLine("intA vaut 3");
}
else
{
    Console.WriteLine("Sinon, intA peut avoir pour valeur n'importe quoi...");
}

/*
 * Le Switch sert à évaluer une multitudes de possbilités dans une syntaxe plus claire qu'une multitude de IF / ELSE IF / ELSE
 * 
 * On peut ainsi faire autant de CASE que l'on veut, et si aucun n'est rencontré par la vérification, alors le DEFAULT sera levé.
 * 
 * Attention à ne pas oublier l'instruction BREAK sous peine d'erreurs
 * 
 */

Console.WriteLine("\nSWITCH");

intA = 6;

switch (intA)
{
    case 1:
        Console.WriteLine("intA vaut 1!");
        break;
    case 3:
        Console.WriteLine("intA vaut 3!");
        break;
    case 6:
        Console.WriteLine("intA vaut 6!");
        break;
    default:
        Console.WriteLine("intA vaut autre chose...");
        break;
}

/*
 * Il est également possible d'évaluer des champs de possibilités dans in Switch, via l'utilisation de cette syntaxe : 
 * 
 * A noter que "blabla" ou "toto" peuvent avoir une valeur aléatoire, cela n'influence pas l'exécution du switch
 * 
 */

Console.WriteLine("\nSWITCH PLUS COMPLEXE");

intA = 5;

switch (intA)
{
    case var blabla when intA > 3:
        Console.WriteLine("intA est supérieur à 3");
        break;
    case var blabla when intA < 3:
        Console.WriteLine("intA est inférieur à 3");
        break;
    case var toto when intA == 3:
        Console.WriteLine("intA est égal à 3");
        break;
    default:
        break;

}

/*
 * Enfin, il est possible de se servir du "witch" pour affecter des variables, tel que dans l'exemple suivant :
 */

string message;

Console.Write("Votre age : ");
int age = Convert.ToInt32(Console.ReadLine());

message = age switch
{
    18 => "Vous êtes majeur en France",
    21 => "Vous êtes majeur aux USA"
};

Console.WriteLine(message);

/*
 * L'opérateur Ternaire
 * 
 * Souvent rencontré lors de recherches sur StackOverflow ou autre, cet opérateur marche en réalité comme un IF / ELSE classique, tel que :
 * 
 * Est-ce que 5 est plus grand que 2 ? Si oui alors ...  Si non alors ...
 * 
 */

Console.WriteLine("\nOPERATEUR TERNAIRE");

intA = 5;

Console.WriteLine($"intA est supérieur à 2 ? {(intA > 2 ? "Oui" : "Non")}");


/*
 * La premier structure itérative est le DO...WHILE, et sert à réaliser une opération tant que la vérification donne le résultat attendu
 * 
 */

Console.WriteLine("=== LES INSTRUCTIONS ITERATIVES ===\n");


intA = 5;
Console.WriteLine($"Avant la boucle, intA vaut {intA}");

do
{
    Console.WriteLine($"Maintenant, intA vaut {intA++}");
} while (intA <=10);

Console.WriteLine($"après la boucle, intA vaut {intA}");

/*
 * A l'inverse, la boucle WHILE vérifie la condition AVANT une première itération
 * 
 */

intA = 10;
Console.WriteLine($"Avant la boucle, intA vaut {intA}");

while (intA >= 5)
{
    Console.WriteLine($"Maintenant, intA vaut {intA--}");
}

Console.WriteLine($"après la boucle, intA vaut {intA}");


/*
 * Ici, on ne rentrera par exemple pas dans la boucle, car la condition de base n'est pas remplie
 * 
 */

intA = 2;
Console.WriteLine($"Avant la boucle, intA vaut {intA}");

while (intA >= 5)
{
    Console.WriteLine($"Maintenant, intA vaut {intA--}");
}

Console.WriteLine($"après la boucle, intA vaut {intA}");

/*
 * La boucle FOR sert à réaliser un nombre connu d'itération. ON spécifie alors la valeur de base de l'itérateur, la valeur limite et son pas
 * 
 * POUR variable ayant pour valeur ... JUSQU'A valeur ... AVEC UN PAS DE valeur du pas ...
 * 
 */

Console.WriteLine("Avant la boucle");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Je me répète !");
}

Console.WriteLine("Après la boucle");

/*
 * La boucle FOREACH sert à itérer au sein d'un élement tel qu'un tableau ou une liste, pour parcourir chacun des élements qui le constitue en s'arrêtant automatiquement au dernier élément
 * 
 * POUR CHAQUE element DE ensemble ...
 * 
 */

string[] tabStrings = new string[5]
{
    "Albert", 
    "Mark", 
    "Angela", 
    "Elliot", 
    "Jacob"
};

foreach (string tabString in tabStrings)
{
    Console.WriteLine(tabString);
}