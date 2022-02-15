using System.Text;

Console.OutputEncoding = Encoding.UTF8;

/* Les différents types de valeurs
 * 
 * En C# les variables sont typées, ce qui implique une utilisation de tel type de valeur en fonction de nos besoins,
 * ce principalement dans un soucis de performance et d'optimisation de la gestion de mémoire.
 */

/* Les variables de nombres entiers 
 * 
 * SBYTE : 8bits
 * SHORT : 16bits
 * INT : 32bits
 * LONG : 64bits
 * 
 * Ces variables peuvent également être non signées pour augmenter leur portée dans les valeurs positives au détriment des négatives
 */

Console.WriteLine($"Le type SBYTE a pour valeur minimale {sbyte.MinValue} et pour valeur maximale {sbyte.MaxValue}. Il utilise une taille en RAM de {sizeof(sbyte)} octet");
Console.WriteLine($"Le type BYTE a pour valeur minimale {byte.MinValue} et pour valeur maximale {byte.MaxValue}. Il utilise une taille en RAM de {sizeof(byte)} octed");
Console.WriteLine($"Le type SHORT a pour valeur minimale {short.MinValue} et pour valeur maximale {short.MaxValue}. Il utilise une taille en RAM de {sizeof(short)} octets");
Console.WriteLine($"Le type CHAR a pour valeur minimale {(int) char.MinValue} et pour valeur maximale {(int) char.MaxValue}. Il utilise une taille en RAM de {sizeof(char)} octets");
Console.WriteLine($"Le type USHORT a pour valeur minimale {ushort.MinValue} et pour valeur maximale {ushort.MaxValue}. Il utilise une taille en RAM de {sizeof(ushort)} octets");
Console.WriteLine($"Le type INT a pour valeur minimale {int.MinValue} et pour valeur maximale {int.MaxValue}. Il utilise une taille en RAM de {sizeof(int)} octets");
Console.WriteLine($"Le type UINT a pour valeur minimale {uint.MinValue} et pour valeur maximale {uint.MaxValue}. Il utilise une taille en RAM de {sizeof(uint)} octets");
Console.WriteLine($"Le type LONG a pour valeur minimale {long.MinValue} et pour valeur maximale {long.MaxValue}. Il utilise une taille en RAM de {sizeof(long)} octets");
Console.WriteLine($"Le type ULONG a pour valeur minimale {ulong.MinValue} et pour valeur maximale {ulong.MaxValue}. Il utilise une taille en RAM de {sizeof(ulong)} octets\n");

/* Les variables de nombres à virgule
 * 
 * FLOAT : Simple précision
 * DOUBLE : Double précision
 * DECIMAL : Encore plus précise, mais des valeurs moins étendues (utilisée surtout pour le bancaire)
 */

float baseFloat = 0.0005f;
Console.WriteLine($"BASEFLOAT vaut {baseFloat}");
double baseDouble = 0.0005;
Console.WriteLine($"BASEDOUBLE vaut {baseDouble}");
decimal baseDecimal = 0.0005m;
Console.WriteLine($"BASEDECIMAL vaut {baseDecimal}\n");

/* Les autres types de variables
 * 
 * CHAR : Une lettre
 * STRING : Une chaine de caractère
 * BOOL : Sert à contenir la valeur Vrai ou la valeur Faux
 */

char letterA = 'a';
Console.WriteLine($"LETTER A vaut {letterA}");
char letterB = (char) 98;
Console.WriteLine($"LETTER B vaut {letterB}");
string baseString = "Le Corbeau et le Renard";
Console.WriteLine($"BASESTRING vaut {baseString}");
bool baseBool = false;
Console.WriteLine($"BASEBOOL vaut {baseBool}\n");

/*
 * Les TABLEAUX
 * 
 * Les variables peuvent également être collecter plusieurs fois et assembler sous la forme de tableaux
 * 
 * Les tableaux doivent avoir une taille donnée, et ne peuvent être agrandis ou rétrécis (Pour cela, on utilise par exemple des listes)
 * On obtient ainsi une série de valeur d'un même type qui peuvent être parcourues via un index sous la forme : 
 * 
 * tableau[index] => valeur de tableau à l'index donné (Attention, l'index commence à 0 et non à 1)
 * 
 */

int[] tab = new[] { 1, 2, 3, 4, 5 };

//int[] tab = new int[5]; 
//for (int i = 0; i < tab.Length; i++) tab[i] = i + 1;

Console.WriteLine($"tab[2] vaut {tab[2]}\n");

/* 
 * Récupérer des valeurs utilisateurs 
 * 
 * Pour récupérer une chaine de caractère entrée par l'utilisateur, on se sert de la méthode .ReadLine() de la classe Console
 * 
 * Ensuite, en cas de nécessité de conversion de type de valeur, on peut faire soit un Casting, soit un Parsing, comme ci-dessous : 
 * 
 * */

// La récupération simple 
Console.Write("Veuilliez entrer une chaine de caractères: ");
string chaine = Console.ReadLine();
Console.WriteLine($"La chaine de caractère entrée est {chaine}");

// Le parsing simple
int nbrEntier = 0;

Console.Write("Veuilliez entrer un nombre entier: ");

try
{
    nbrEntier = int.Parse(Console.ReadLine());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine($"Le nombre entier entré  est {nbrEntier}");

// Le parsing sécurisé
Console.Write("Veuilliez entrer un nombre décimal: ");
double nbrDecimal;
if (double.TryParse(Console.ReadLine(), out nbrDecimal))
    Console.WriteLine($"Le nombre décimal entré est {nbrDecimal}");
else
    Console.WriteLine("Le parsing n'a pas abouti...");

/*
 * Le casting consiste en la modification des types des variables, 
 * par exemple tranformer un chiffre à virgule en chiffre entier et inversement
 * */

// Le casting implicite
Console.Write("Veuilliez entrer un entier : ");
int entier = Convert.ToInt32(Console.ReadLine());
double entierEnDouble = entier;
Console.WriteLine($"La valeur en double est {entierEnDouble}.");

// Le casting explicite
Console.Write("Veuilliez entrer un chiffre à virgule : ");
double chiffreAVirgule = Convert.ToDouble(Console.ReadLine());
int doubleEnInt = (int)chiffreAVirgule;
Console.WriteLine($"Le chiffre entier est {doubleEnInt}");
