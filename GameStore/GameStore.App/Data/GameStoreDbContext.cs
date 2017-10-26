
namespace GameStore.App.Data
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;

   public class GameStoreDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server = .\\tg; Database=GameStore; Integrated Security = true");


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }
}
