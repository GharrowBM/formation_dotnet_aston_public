using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06.Datas
{
    internal class BaseRepository
    {
        protected DataContext _context;

        public BaseRepository()
        {
            _context = new DataContext();
        }
    }
}
