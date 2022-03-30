using EX04_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EX04_API.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
