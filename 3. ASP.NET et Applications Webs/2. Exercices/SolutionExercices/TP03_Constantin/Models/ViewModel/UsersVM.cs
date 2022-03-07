using static Bookstore.Models.Users;

namespace Bookstore.Models.ViewModel
{
    public class UsersVM
    {
        #pragma warning disable
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleEnum? Role { get;}
    }
}