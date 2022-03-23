using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstAppTodoList.Models
{
    public class Todo
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDone { get; set; }
        public Urgence? Urgence { get; set; }
    }

    public enum Urgence
    {
        Urgent,
        Important,
        NotImportant,
        IfYouHaveTime
    }
}
