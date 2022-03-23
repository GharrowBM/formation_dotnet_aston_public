using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXO_01.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsDone { get; set; }

    }
}
