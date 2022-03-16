using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C05_EFCore.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [StringLength(50)]
        [Required(ErrorMessage = "Le chien doit avoir un nom")]
        public string Name { get; set; }

        [Display(Name = "Couleur du collier")]
        [Required(ErrorMessage = "Le chien doit avoir une couleur de collier")]
        public CollarColor CollarColor { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Le chien doit avoir un âge")]
        public int Age { get; set; }
    }

    public enum CollarColor
    {
        White,
        Black,
        Red,
        Green,
        Blue,
        Yellow,
        Purple,
        Orange
    }
}
