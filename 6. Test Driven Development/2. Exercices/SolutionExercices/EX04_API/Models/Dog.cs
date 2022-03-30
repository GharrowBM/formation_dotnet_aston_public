using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EX04_API.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le chien doit avoir un nom !")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Couleur de collier")]
        public CollarColor CollarColor { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "Le chien doit avoir une date de naissance !")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Maître")]
        public int? MasterId { get; set; }

        [ForeignKey("MasterId")]
        public virtual Master? Master { get; set; }
    }

    public enum CollarColor
    {
        White,
        Black,
        Blue,
        Red,
        Green,
        Violet,
        Yellow,
        Orange
    }
}
