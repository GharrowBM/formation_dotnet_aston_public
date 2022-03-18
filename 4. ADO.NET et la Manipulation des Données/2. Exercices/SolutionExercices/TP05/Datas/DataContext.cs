using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05.Classes;

namespace TP05.Datas
{
    internal class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }

        private static DataContext instance;
        
        public static DataContext Instance
        {
            get
            {
                if (instance == null) return new DataContext();
                else return instance;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddUserSecrets<Program>()
            .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("Default"));
        }
    }
}
