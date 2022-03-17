using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP04B.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name ="Prénom")]
        [Required(ErrorMessage ="La personne doit avoir un prénom")]
        public string Firstname { get; set; }

        [StringLength(50)]
        [Display(Name ="Nom")]
        [Required(ErrorMessage ="La personne doit avoir un nom")]
        public string Lastname { get; set; }

        [Display(Name ="Nom complet")]
        public string Fullname { get { return Firstname + " " + Lastname; } }

        [StringLength(15)]
        [Display(Name ="Numéro de téléphone")]
        [Required(ErrorMessage ="La personne doit avoir un numéro de téléphone")]
        public string Phone { get; set; }

        [EmailAddress]
        [Display(Name ="Adresse mail")]
        [Required(ErrorMessage ="La personne doit avoir une adresse mail")]
        public string Email { get; set; }

        [Display(Name ="Adresse")]
        public int? AdressId { get; set; }

        [ForeignKey("AdressId")]
        public virtual Adress? Adress { get; set; }
    }
}
