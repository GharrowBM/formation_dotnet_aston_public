using System.ComponentModel.DataAnnotations;

namespace C02_ASPNet.Models.ViewModels
{
    public class DogVM
    {
        [Display(Name = "Nom du chien")]
        [Required(ErrorMessage = "Le chien doit avoir un nom !")]
        public string Name { get; set; }
        public int NbOfLegs { get; set; }

        [Display(Name ="Maître")]
        public int MasterId { get; set; }

        [Display(Name = "Couleur du collier")]
        public CollarColor CollarColor { get; set; }
    }
}
