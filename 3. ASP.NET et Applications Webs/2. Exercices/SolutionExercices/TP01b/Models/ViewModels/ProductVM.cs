using System.ComponentModel.DataAnnotations;

namespace CaisseEnregistreuse.Models.ViewModels
{
    public class ProductVM
    {
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le produit doit avoir un nom !")]
        public string Name { get; set; }

        [Display(Name = "Description du produit")]
        public string Description { get; set; }

        [Display(Name = "Prix")]
        [Required(ErrorMessage = "Le produit doit avoir un prix !")]
        public decimal Price { get; set; }
    }
}
