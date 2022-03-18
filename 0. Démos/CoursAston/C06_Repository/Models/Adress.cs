using System.ComponentModel.DataAnnotations;

namespace C05_EFCore.Models
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Numéro de voie")]
        [Required(ErrorMessage = "Il faut un numéro de rue")]
        public int StreetNumber { get; set; }

        [Display(Name ="Nom de voie")]
        [Required(ErrorMessage = "Il faut un nom de rue")]
        public string StreetName { get; set; }

        [Display(Name ="Code Postal")]
        [Required(ErrorMessage = "Il faut un code postal")]
        public int PostalCode { get; set; }

        [Display(Name ="Commune")]
        [Required(ErrorMessage = "Il faut un nom de commune")]
        public string CityName { get; set; }
        public string FullAdress { get => $"{StreetNumber} {StreetName} - {PostalCode} {CityName}"; }
    }
}
