using System.Text;

Console.OutputEncoding = Encoding.UTF8;

int intA, intB, intC;
double doubleA, doubleB, doubleC;
string stringA, stringB, stringC;
bool comparaison;

/*
 * Les Opérateurs Arithmétiques
 * 
 * Parmis les opérateurs, les plus communs sont : 
 * L'Addition (+) ajoute deux nombres l'un à l'autre, ou concatène deux chaines de caractère (les assemble)
 * La Soustraction (-) soustrait deux nombres l'un à l'autre
 * La Division (/) divise un nombre par un autre
 * La Multiplication (*) multiplie un nombre par un autre
 * Le Modulo (%) donne le reste d'une division euclidienne (entière) d'un nombre par un autre
 * 
 */

Console.WriteLine("=== LES OPERATEURS ARITHMETIQUES ===\n");

Console.WriteLine("LES ENTIERS");

intA = 1;
intB = 1;
intC = intA + intB;
Console.WriteLine($"Addition d'entiers : {intA} + {intB} = {intC}");

intA = 5;
intB = 2;
intC = intA - intB;
Console.WriteLine($"Soustraction d'entiers : {intA} - {intB} = {intC}");

intA = 10;
intB = 3;
intC = intA / intB;
Console.WriteLine($"Division d'entiers : {intA} / {intB} = {intC}");

intA = 2;
intB = 6;
intC = intA * intB;
Console.WriteLine($"Multiplication d'entiers : {intA} * {intB} = {intC}");

intA = 5;
intB = 3;
intC = intA % intB;
Console.WriteLine($"Modulo d'entiers : {intA} % {intB} = {intC}\n");


Console.WriteLine("LES DECIMAUX");

doubleA = 1;
doubleB = 1;
doubleC = doubleA + doubleB;
Console.WriteLine($"Addition de décimaux : {doubleA} + {doubleB} = {doubleC}");

doubleA = 5;
doubleB = 2;
doubleC = doubleA - doubleB;
Console.WriteLine($"Soustraction de décimaux : {doubleA} - {doubleB} = {doubleC}");

doubleA = 10;
doubleB = 3;
doubleC = doubleA / doubleB;
Console.WriteLine($"Division de décimaux : {doubleA} / {doubleB} = {doubleC}");

doubleA = 2;
doubleB = 6;
doubleC = doubleA * doubleB;
Console.WriteLine($"Multiplication de décimaux : {doubleA} * {doubleB} = {doubleC}");

doubleA = 5;
doubleB = 3;
doubleC = doubleA % doubleB;
Console.WriteLine($"Modulo de décimaux : {doubleA} % {doubleB} = {doubleC}\n");

Console.WriteLine("LES CHAINES DE CARACTERES");

stringA = "Le Chat";
stringB = "Le Chien";
stringC = stringA + stringB;
Console.WriteLine($"Addition (Concaténation) de chaines : {stringA} + {stringB} = {stringC}\n");
/*
 * Les Opérateurs de comparaison
 * 
 * Les opérateurs de comparaisons servent à vérifier la relation qu'on deux variables entre elles, tels que :
 * L'Egalité (==)
 * La Différence (!=)
 * La Supériorité Exclusive (>)
 * La Supériorité Inclusive (>=)
 * L'Infériorité Exclusive (<)
 * L'Infériorité Inclusive (<=)
 * 
 */

Console.WriteLine("=== LES OPERATEURS DE COMPARAISON ===\n");

intA = 2;
intB = 5;
comparaison = intA == intB;
Console.WriteLine($"Le nombre {intA} est EGAL au nombre {intB} ? {comparaison}");

intA = 2;
intB = 5;
comparaison = intA != intB;
Console.WriteLine($"Le nombre {intA} est DIFFERENT du nombre {intB} ? {comparaison}");

intA = 5;
intB = 5;
comparaison = intA > intB;
Console.WriteLine($"Le nombre {intA} est STRICTEMENT SUPERIEUR au nombre {intB} ? {comparaison}");

intA = 5;
intB = 5;
comparaison = intA >= intB;
Console.WriteLine($"Le nombre {intA} est SUPERIEUR OU EGAL au nombre {intB} ? {comparaison}");

intA = 2;
intB = 5;
comparaison = intA < intB;
Console.WriteLine($"Le nombre {intA} est STRICTEMENT INFERIEUR au nombre {intB} ? {comparaison}");

intA = 2;
intB = 5;
comparaison = intA <= intB;
Console.WriteLine($"Le nombre {intA} est INFERIEUR OU EGAL au nombre {intB} ? {comparaison}\n");

/*
 * Les Opérateurs booléens
 * 
 * Ces opérateurs servent à faire des opérations de comparaison logiques, pour réaliser l'équivalent des tables de vérités : 
 * 
 * Le ET (&&)
 * le OU (||) 
 * 
 */

Console.WriteLine("=== LES OPERATEURS LOGIQUES ===\n");

Console.WriteLine("Table de vérité basique de référence : ");
Console.WriteLine($" {true, 5} ET {true, 5} = {true && true, 5} | {true, 5} OU {true, 5} = {true || true, 5}");
Console.WriteLine($" {true, 5} ET {false, 5} = {true && false, 5} | {true, 5} OU {false, 5} = {true || false, 5}");
Console.WriteLine($" {false, 5} ET {true, 5} = {false && true, 5} | {false, 5} OU {true, 5} = {false || true, 5}");
Console.WriteLine($" {false, 5} ET {false, 5} = {false && false, 5} | {false, 5} OU {false, 5} = {false || false, 5}\n");


/*
 * Les Opérateurs Unaires 
 * 
 * Ces opérateurs fonctionnent un peu différemment, et l'on utilise principalement ces derniers : 
 * L'Incrementation (++)
 * La Décrémentation (--)
 * L'Inversion (!)
 * 
 * Dans le cas des deux premiers, en fonction de si l'opérateur est avant ou après la variable, le résultat ne sera pas le même
 * 
 */

Console.WriteLine("=== LES OPERATEURS UNAIRES ===\n");

intA = 10;
Console.WriteLine($"Valeur de base de intA : {intA}");
intA = 10;
Console.WriteLine($"Incrémentation classique : intA++ = {intA++} => {intA}");
intA = 10;
Console.WriteLine($"Incrémentation en préfixe : ++intA = {++intA} => {intA}\n");

intA = 10;
Console.WriteLine($"Valeur de base de intA : {intA}");
intA = 10;
Console.WriteLine($"Décrémentation classique : intA-- = {intA--} => {intA}");
intA = 10;
Console.WriteLine($"Décrémentation en préfixe : --intA = {--intA} => {intA}\n");

comparaison = true;
Console.WriteLine($"Valeur de base de comparaison : {comparaison}");
Console.WriteLine($"Inversion : !comparaison = {!comparaison}\n");