namespace Bookstore.Models.ViewModel
{
    #pragma warning disable
    public class AuthorsVM
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Biography { get; set; }

    }
}