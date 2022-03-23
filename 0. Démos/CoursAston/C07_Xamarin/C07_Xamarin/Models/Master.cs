using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace C07_Xamarin.Models
{
    public class Master
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public int Age 
        {
            get
            {
                int age = DateTime.Today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
                return age;
            }
        }

        public DateTime DateOfBirth { get; set; }

        public int AddressId { get; set; }


        public override string ToString()
        {
            return FullName + " - " + Email.ToLower();
        }

    }
}
