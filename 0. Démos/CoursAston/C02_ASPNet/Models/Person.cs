namespace C02_ASPNet.Models
{
    public class Person
    {
        public static int Count;
        public int Id { get; set; }
        public string Name { get; set; }

        public Person()
        {
            Id = ++Count;
        }

    }
}
