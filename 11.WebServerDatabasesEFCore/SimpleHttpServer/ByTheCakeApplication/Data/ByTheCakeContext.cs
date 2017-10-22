

namespace SimpleHttpServer.ByTheCakeApplication.Data
{
    using Microsoft.EntityFrameworkCore;
    using SimpleHttpServer.ByTheCakeApplication.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;


    class ByTheCakeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<User> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(".\tg; Database=ByTheCakeDb; Integrated Security = true");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Order>()
                .HasOne(u=> u.User)
                .WithMany(o=>o.Orders)
                .HasForeignKey(fk=>fk.UserId)


                .

        }
    }
}
