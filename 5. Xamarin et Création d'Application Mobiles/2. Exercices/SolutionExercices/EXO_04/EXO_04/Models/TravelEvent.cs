using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXO_02.Models
{
    public class TravelEvent
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string RemainingDays 
        { 
            get
            {
                int daysRemainings = DateTime.Today.Subtract(Date).Days;
                if(daysRemainings < 0)
                {
                    return $"J{daysRemainings}";
                }
                else if (daysRemainings > 0)
                {
                    return "PASSED";
                }
                else
                {
                    return "TODAY";
                }
            } 
        }
    }
}
