#pragma warning disable
namespace Bookstore.Models
{
    public class Users
    {
        //private |_id , _name , _email , _password , _role |Enum : admin, user
        public static int _compteur = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set;}

        public Users()
        {
            Id = ++_compteur;
            Role = RoleEnum.user;
        }

        public enum RoleEnum
        {
            admin,
            user
        }
    }
}
