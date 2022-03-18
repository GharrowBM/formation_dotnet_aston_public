using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C05_EFCore.Models
{
    public class Master
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Prénom")]
        [Required(ErrorMessage ="Il faut un prénom au maître")]
        public string Firstname { get; set; }
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Il faut un nom au maître")]
        public string Lastname { get; set; }

        [Display(Name = "Nom complet")]
        public string Fullname { get => Firstname + " " + Lastname; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Il faut un email au maître")]
        public string Email { get; set; }

        [Display(Name = "Téléphone")]
        [Required(ErrorMessage = "Il faut un téléphone au maître")]
        public string Phone { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Il faut une adresse au maître")]
        public int AdressId { get; set; }

        [ForeignKey("AdressId")]
        public virtual Adress? Adress { get; set; }
    }
}
