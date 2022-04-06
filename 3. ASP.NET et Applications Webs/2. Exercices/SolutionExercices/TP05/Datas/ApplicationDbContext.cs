using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TP05.Models;

namespace TP05.Datas
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<Pizza> Pizzas { get; set; }

        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            SqlConnection connection = (SqlConnection)Database.GetDbConnection();
            connection.AccessToken = new DefaultAzureCredential().GetToken(new TokenRequestContext(new[] {"http://database.windows.net/.default"})).Token;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionString:Default"]);
        }
    }
}
