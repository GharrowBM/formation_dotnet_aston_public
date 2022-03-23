using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace C07_Xamarin.Models
{
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int StreetNumber { get; set; }

        [MaxLength(200)]
        public string StreetName { get; set; }
        public int PostalCode { get; set; }

        [MaxLength(100)]
        public string CityName { get; set; }

        public override string ToString()
        {
            return $"{StreetNumber} {StreetName.ToUpper()} - {PostalCode} {CityName.ToUpper()}";
        }
    }
}
