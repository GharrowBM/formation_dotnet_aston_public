using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EX04_API.Models
{
    public class Master
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le maître doit avoir un prénom !")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le maître doit avoir un nom !")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Nom complet")]
        public string FullName { get => FirstName + " " + LastName; }

        [Display(Name = "Adresse email")]
        [Required(ErrorMessage = "Le maître doit avoir une adresse email !")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Numéro de téléphone")]
        [Required(ErrorMessage = "Le maître doit avoir un numéro de téléphone !")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Display(Name = "Adresse")]
        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address? Address { get; set; }

    }
}
