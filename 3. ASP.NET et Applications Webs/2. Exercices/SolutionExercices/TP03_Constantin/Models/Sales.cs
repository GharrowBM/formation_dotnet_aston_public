#pragma warning disable
namespace Bookstore.Models
{
    public class Sales
    {
        //id , buyer(users) , list book , date
        public int Id { get; set; }
        public Users Buyer { get; set; }
        public List<Books> ListBook { get; set; }
        public DateTime Date { get; set; }

        public bool isFinished { get; set; }

        public static int _compteur = 0;

        public Sales()
        {
            Id = ++_compteur;
            Date = DateTime.Now;
            isFinished = false;
        }

    }
}
