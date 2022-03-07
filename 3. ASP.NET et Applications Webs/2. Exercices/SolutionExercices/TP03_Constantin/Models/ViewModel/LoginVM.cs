using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.ViewModel
{
    #pragma warning disable
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}
