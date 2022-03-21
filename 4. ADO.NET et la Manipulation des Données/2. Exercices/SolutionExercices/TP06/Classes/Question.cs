using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06.Classes
{
    internal class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public virtual List<Reponse> Reponses { get; set; }
        public int PosteurId { get; set; }
        [ForeignKey("PosteurId")]

        public Utilisateur Posteur { get; set; }

        public Question()
        {
            Reponses = new List<Reponse>();
        }
    }
}
