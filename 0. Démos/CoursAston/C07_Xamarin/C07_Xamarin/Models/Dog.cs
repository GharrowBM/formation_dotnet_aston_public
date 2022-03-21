using System;
using System.Collections.Generic;
using System.Text;

namespace C07_Xamarin.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public static int Count;
        public string Name { get; set; }
        public string Description { get; set; }

        public Dog()
        {
            Id = ++Count;
        }
    }
}
