using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Classes
{
    public class Album
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Song> Songs { get; set; }

        public Album()
        {
            Songs = new List<Song>();
        }
    }
}
