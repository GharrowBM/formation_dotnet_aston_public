namespace C03_WebAPI.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NbOfLegs { get; set; }
        public string CollarColor { get; set; }

        public static int Count;
        public Dog()
        {
            Id = ++Count;
        }
    }
}
