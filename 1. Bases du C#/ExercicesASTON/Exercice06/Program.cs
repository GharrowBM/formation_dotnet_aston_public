Console.WriteLine("--- Calcul du périmètre et de l'aire d'un carré ---");
Console.Write("Entrez la longueur d'un côté du carré (en cm) : ");
double coteCarre = Convert.ToDouble(Console.ReadLine());
double perimetreCarre = coteCarre * 4;
double aireCarre = coteCarre * coteCarre;
Console.WriteLine("Le périmètre du carré est de : " + perimetreCarre + " cm");
Console.WriteLine("L'aire du carré est : " + aireCarre + " cm2");

Console.WriteLine("--- Calcul du périmètre et de l'aire d'un rectangle ---");
Console.Write("Entrez la longueur du rectangle (en cm) : ");
double longueurRectangle = Convert.ToDouble(Console.ReadLine());
Console.Write("Entrez la largeur du rectangle (en cm) : ");
double largeurRectangle = Convert.ToDouble(Console.ReadLine());
double perimetreRectangle = longueurRectangle * 2 + largeurRectangle * 2;
double aireRectangle = longueurRectangle * largeurRectangle;
Console.WriteLine("Le périmètre du rectangle est de : " + largeurRectangle + " cm");
Console.WriteLine("L'aire du rectangle est : " + aireRectangle + " cm2");

