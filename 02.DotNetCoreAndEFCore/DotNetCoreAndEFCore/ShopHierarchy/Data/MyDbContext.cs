
using Microsoft.EntityFrameworkCore;

namespace ShopHierarchy.Data
{
    class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Salesman> Salesmans { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(local)\\tg;user id=sa;password=123; Database=EFCoreTest;Pooling=false; Trusted_Connection=True");
            base.OnConfiguring(builder);
        }
   
       protected override void  OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Customer>()
                .HasOne(p => p.Salesman)
                .WithMany(c => c.Customers)
                .HasForeignKey(fk => fk.SalesmanId);

            builder
                .Entity<Customer>()
                .HasMany(o => o.Orders)
                .WithOne(c => c.Customer)
                .HasForeignKey(fk => fk.CustomerId);

            builder
                .Entity<Customer>()
                .HasMany(r => r.Reviews)
                .WithOne(c => c.Customer)
                .HasForeignKey(fk => fk.CustomerId);


            builder
                .Entity<OrderItems>()
                .HasKey(pk => new { pk.ItemId, pk.OrderId });

            builder
                .Entity<OrderItems>()
                .HasOne(c => c.Order)
                .WithMany(m => m.Items)
                .HasForeignKey(fk => fk.OrderId);


            builder
               .Entity<OrderItems>()
               .HasOne(c => c.Item)
               .WithMany(m => m.Orders)
               .HasForeignKey(fk => fk.ItemId);

            builder
                .Entity<Item>()
                .HasMany(m => m.Reviews)
                .WithOne(o => o.Item)
                .HasForeignKey(fk => fk.ItemId);
        }

    }
}
