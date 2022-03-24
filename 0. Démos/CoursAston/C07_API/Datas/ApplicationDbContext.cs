using C07_API.Models;
using Microsoft.EntityFrameworkCore;

namespace C07_API.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
    }
}
