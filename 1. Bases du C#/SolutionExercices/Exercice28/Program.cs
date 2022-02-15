Console.WriteLine("--- Trouver le nombre mystère ---");

int mysteryNumber = new Random().Next(51);
int inputValue = 51, i = 1;

while (inputValue != mysteryNumber)
{
    Console.Write("Veuilliez entrer un nombre : ");
    if (int.TryParse(Console.ReadLine(), out inputValue))
    {
        if (inputValue == mysteryNumber)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Bravo, vous avez trouvé le nombre mystère en {i} tentatives !");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        }
        else if (inputValue > mysteryNumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Le nombre mystère est plus petit.");
            i++;
        }
        else if (inputValue < mysteryNumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Le nombre mystère est plus grand.");
            i++;
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}