using C05_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace C05_EFCore.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Adress> Adresses { get; set; }
    }
}
