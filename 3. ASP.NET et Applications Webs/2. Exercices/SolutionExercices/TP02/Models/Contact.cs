using System.ComponentModel.DataAnnotations;

namespace TP02.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public static int Compteur { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Prenom manquant !")]
        public string Firstname { get; set; }

        [Display(Name ="Nom")]
        [Required(ErrorMessage = "Nom manquant !")]
        public string Lastname { get; set; }

        [Display(Name = "Nom complet")]
        public string Fullname
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }

        [Display(Name = "Téléphone")]
        [Required(ErrorMessage = "Téléphone manquant !")]
        public string Phone { get; set; }

        [Display(Name = "Adresse mail")]
        [Required(ErrorMessage = "Email manquant !")]
        public string Email { get; set; }

        [Display(Name = "Avatar")]
        public Avatar Avatar { get; set; }

        public Contact()
        {
            Id = ++Compteur;
        }

    }
}
