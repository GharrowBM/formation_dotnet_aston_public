using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace C07_Xamarin.Models
{
    public class Dog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public CollarColor CollarColor { get; set; }

        public int MasterId { get; set; }
    }

    public enum CollarColor
    {
        White,
        Black,
        Red,
        Green,
        Blue,
        Yellow,
        Violet,
        Orange
    }
}
