using System.ComponentModel.DataAnnotations;

namespace CaisseEnregistreuse.Models.ViewModels
{
    public class ClientVM
    {
        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le client doit avoir un prénom !")]
        public string FirstName { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le client doit avoir un nom !")]
        public string LastName { get; set; }

        [Display(Name = "Téléphone")]
        [Required(ErrorMessage = "Le client doit avoir un numéro de téléphone!")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Le client doit avoir un émail !")]
        public string Email { get; set; }
    }
}
