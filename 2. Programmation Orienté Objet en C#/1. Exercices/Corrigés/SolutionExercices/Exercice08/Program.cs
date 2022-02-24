using Exercice08.Classes;

Boite boiteA = new Boite(2, 2, 2);
Boite boiteB = new Boite(3, 3, 3);

Boite boiteC = boiteA + boiteB;
Boite boiteD = boiteA * boiteB;

Console.WriteLine("En rangeant la boite A sur la boite B, on obtient : ");
Console.WriteLine(boiteC);
Console.WriteLine("En rangeant la boite A en biais de la boite B, on obtient : ");
Console.WriteLine(boiteD);