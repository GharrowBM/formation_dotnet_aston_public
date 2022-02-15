Console.WriteLine("--- Les suites chaînées de nombres ---\n");
Console.Write("Merci de saisir un nombre :");

int value = int.Parse(Console.ReadLine());

Console.WriteLine("Les chaînes possibles sont :");

int i = 1;

while (i <= value / 2)
{
    int j = i + 1;
    string str = $"{value} = {i}";
    int sum = i;

    while (j <= value / 2 + 1)
    {
        sum = sum + j;
        str += $"+{j}";
        if (sum == value)
        {
            Console.WriteLine(str);
            break;
        }
        else if (sum > value)
        {
            break;
        }

        j++;
    }

    i++;
}