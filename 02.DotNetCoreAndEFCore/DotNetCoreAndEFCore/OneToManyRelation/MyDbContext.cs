


namespace OneToManyRelation
{
    using Microsoft.EntityFrameworkCore;

    class MyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(local)\\tg;user id=sa;password=123; Database=EFCoreTest;Pooling=false; Trusted_Connection=True");
            base.OnConfiguring(builder);
        }





        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder
                .Entity<Department>()
                .HasMany(e => e.Employees)
                .WithOne(d => d.Department)
                .HasForeignKey(fk => fk.DepartmentId);

            builder
                .Entity<Employee>()
                .HasOne(m => m.Manager)
                .WithMany(mt => mt.ManagerTeam)
                .HasForeignKey(fk => fk.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
            
            /*

            builder
                .Entity<FriendShip>()
                .HasKey(fk => new { fk.UserId, fk.FriendId });

            builder
                .Entity<FriendShip>()
                .HasOne(u => u.User)
                .WithMany(fr => fr.FriendsofMine)
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
             builder
                .Entity<FriendShip>()
                .HasOne(u => u.Friend)
                .WithMany(fr => fr.FriendsToMe)
                .HasForeignKey(fk => fk.FriendId).OnDelete(DeleteBehavior.Restrict);
          */  
        }
















    }


}
