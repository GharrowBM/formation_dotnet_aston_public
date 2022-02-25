using _02_Heritage.Classes;

List<Animal> animals = new();

Dog rex = new("Rex", 7, false, 4);
Dog arnold = new("Arnold", 4, true, 3);
Fox mickael = new("Mickael", 6, true, 4);

animals.Add(rex);
animals.Add(arnold);
animals.Add(mickael);

foreach (Animal a in animals)
{
    Console.WriteLine(a);

    if (a is Dog) a.Move("Ses pattes");
    if (a is Fox) a.Move("La musique");

    a.MakeSound();
}
