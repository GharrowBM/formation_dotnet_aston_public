using System.ComponentModel.DataAnnotations;

namespace EX04_API.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Display (Name = "Numéro de voie")]
        [Required(ErrorMessage = "L'adresse doit avoir un numéro de voie !")]
        public int StreetNumber { get; set; }

        [Display (Name = "Intitulé de voie")]
        [Required(ErrorMessage = "L'adresse doit avoir un intitulé de voie !")]
        [StringLength(100)]
        public string StreetName { get; set; }

        [Display (Name = "Code postal")]
        [Required (ErrorMessage = "L'adresse doit avoir un code postal !")]
        public int PostalCode { get; set; }

        [Display (Name = "Nom de commune")]
        [Required (ErrorMessage = "l'adresse doit avoir un nom de commune !")]
        [StringLength(50)]
        public string CityName { get; set; }
    }
}
