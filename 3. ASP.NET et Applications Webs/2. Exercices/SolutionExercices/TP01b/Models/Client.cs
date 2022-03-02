namespace CaisseEnregistreuse.Models
{
    public class Client
    {
        public static int Count;
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName;} }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public Client()
        {
            Id = ++Count;
        }
    }
}
