using System.ComponentModel.DataAnnotations;

namespace TP04B.Models
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Numéro de voie")]
        [Required(ErrorMessage ="L'adresse doit comporter un numéro de voie")]
        public int StreetNumber { get; set; }

        [Display(Name = "Nom de voie")]
        [StringLength(100)]
        [Required(ErrorMessage = "L'adresse doit comporter un nom de voie")]
        public string StreetName { get; set; }

        [Display(Name = "Code postal")]
        [StringLength(10)]
        [Required(ErrorMessage = "L'adresse doit comporter un code postal")]
        public string PostalCode { get; set; }

        [Display(Name = "Commune")]
        [StringLength(50)]
        [Required(ErrorMessage = "L'adresse doit comporter une commune")]
        public string CityName { get; set; }

        public string FullAdress { get { return StreetNumber + " " + StreetName + " - " + PostalCode + " " + CityName; } }

        [Display(Name = "Région")]
        [StringLength(50)]
        [Required(ErrorMessage = "L'adresse doit comporter une région")]
        public string RegionName { get; set; }

        [Display(Name = "Pays")]
        [StringLength(50)]
        [Required(ErrorMessage = "L'adresse doit comporter un pays")]
        public string CountryName { get; set; }
        public virtual IEnumerable<Person>? Persons { get; set; }
    }
}
