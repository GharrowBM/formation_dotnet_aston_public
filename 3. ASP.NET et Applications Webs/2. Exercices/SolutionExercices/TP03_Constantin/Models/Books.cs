namespace Bookstore.Models
{
    #pragma warning disable
    public class Books
    {
        //id , title , description , price , list author , list category
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string ISBN { get; set; }
        public DateTime DateParution { get; set; }
        public Authors Author { get; set; }
        public List<Categories> ListCategory { get; set; }

        public static int _compteur = 0;

        public Books()
        {
            Id = ++_compteur;
        }

        public enum Categories
        {
            Adventure,
            Fantasy,
            Horror,
            Romance,
            ScienceFiction,
            Thriller,
            Mystery,
            SelfHelp,
            Biography,
            Poetry,
            History,
            Fiction,
            Children,
            Religion,
        }
    }
}
