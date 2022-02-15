char[] charTable = new char[26];

for (int i = 0; i < 26; i++)
{
    charTable[i] = (char)(i + 65);
}

for (int i = 0; i < 26; i++)
{
    for (int j = 0; j < i; j++)
    {
        Console.Write("  ");
    }

    Console.WriteLine(charTable[i]);
}