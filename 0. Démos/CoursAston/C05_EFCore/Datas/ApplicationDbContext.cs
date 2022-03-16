using C05_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace C05_EFCore.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base (options)
        {
        }
    }
}
