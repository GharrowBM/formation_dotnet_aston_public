namespace C02_ASPNet.Models
{
    public class Dog
    {
        public static int Count;
        public int Id { get; set; }
        public string Name { get; set; }
        public int NbOfLegs { get; set; }
        public Person Master { get; set; }
        public CollarColor CollarColor { get; set; }

        public Dog()
        {
            Id = ++Count;
        }
    }

public enum CollarColor
{
    None, 
    Blue,
    Red,
    Green,
    Orange,
    Pink,
    White,
    Black
}
}
