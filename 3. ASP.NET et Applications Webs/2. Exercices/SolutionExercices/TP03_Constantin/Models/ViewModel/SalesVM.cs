using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.ViewModel
{
    #pragma warning disable
    public class SalesVM
    {
        public int? Id { get; set; }
        [Required]
        public List<int> ListBookId { get; set; }

        [Required]
        public int AuthorId { get; set; }
        
    }
}