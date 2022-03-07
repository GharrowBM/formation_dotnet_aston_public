namespace Bookstore.Models
{
    #pragma warning disable
    public class Authors
    {
        //id , name , family name , birth date , death date , biography , list book
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Biography { get; set; }


        public static int _compteur = 0;

        public Authors()
        {
            Id = ++_compteur;
        }

    }
}
