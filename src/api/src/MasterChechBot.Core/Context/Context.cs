using MasterChechBot.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterChechBot.Core.Context
{
    public class Context : DbContext
    {
        public static string ConnectionString;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public Context(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
    
}
