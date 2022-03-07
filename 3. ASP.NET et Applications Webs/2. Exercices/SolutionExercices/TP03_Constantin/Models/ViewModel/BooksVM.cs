using System.ComponentModel.DataAnnotations;
using static Bookstore.Models.Books;

namespace Bookstore.Models.ViewModel
{
#pragma warning disable
    public class BooksVM
    {
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int AuthorId { get; set; }

        public DateTime DateParution { get; set; }
        public List<Categories>? ListCategory { get; set; }
    }
}
