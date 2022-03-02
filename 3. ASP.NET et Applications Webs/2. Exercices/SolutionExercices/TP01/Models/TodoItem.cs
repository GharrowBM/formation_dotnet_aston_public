using System.ComponentModel.DataAnnotations;
using TP01.Models.Enums;

namespace TP01.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Display(Name = "Titre de la tâche")]
        public string Title { get; set; }

        [Display(Name = "Description de la tâche")]
        public string Description { get; set; }

        public static int Compteur; 

        public TodoItem(string title, string description)
        {
            Id = ++Compteur;
            Title = title;
            Description = description;
        }
    }
}
