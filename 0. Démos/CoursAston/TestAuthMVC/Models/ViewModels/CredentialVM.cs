using System.ComponentModel.DataAnnotations;

namespace TestAuthMVC.Models.ViewModels
{
    public class CredentialVM
    {
        [Display(Name = "Nom d'utilisateur")]
        public string UserName { get; set; }

        [Display(Name ="Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Se souvenir de moi")]
        public bool RememberMe { get; set; }
    }
}
