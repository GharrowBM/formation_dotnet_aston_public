using Microsoft.EntityFrameworkCore;
using TP04B.Models;

namespace TP04B.Datas
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base (options)
        {
        }

    }
}
