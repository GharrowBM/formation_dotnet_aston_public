Console.WriteLine("--- Quelle est la nature du triangle ABC ? ---\n");
Console.Write("Entrez la longueur du segment AB : ");
double segmentAB = double.Parse(Console.ReadLine());
Console.Write("Entrez la longueur du segment BC : ");
double segmentBC = double.Parse(Console.ReadLine());
Console.Write("Entrez la longueur du segment AC : ");
double segmentAC = double.Parse(Console.ReadLine());

if (segmentAB == segmentAC && segmentAC == segmentBC)
{
    Console.WriteLine("Le triangle est équilatéral");
}
else if (segmentAB == segmentAC)
{
    Console.WriteLine("Le triangle est isocèle en A mais n'est pas équilatéral");
}
else if (segmentAB == segmentBC)
{
    Console.WriteLine("Le triangle est isocèle en B mais n'est pas équilatéral");
}
else if (segmentBC == segmentAC)
{
    Console.WriteLine("Le triangle est isocèle en C mais n'est pas équilatéral");
}
else
{
    Console.WriteLine("Le triangle n'est ni isocèle en A, ni en B, ni en C");
}