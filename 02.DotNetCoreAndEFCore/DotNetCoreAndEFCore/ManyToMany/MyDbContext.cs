


namespace ManyToMany
{
    using Microsoft.EntityFrameworkCore;

    class MyDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

            builder.UseSqlServer("Server=(local)\\tg;Database=EFCoreTest;Trusted_Connection=True");
            base.OnConfiguring(builder);
        }





        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<StudentCourse>()
                .HasKey(pk => new { pk.CourseId, pk.StudentId });

            builder
                .Entity<StudentCourse>()
                .HasOne(s => s.Student)
                .WithMany(cs => cs.Courses)
                .HasForeignKey(fk => fk.StudentId);

            builder
                .Entity<StudentCourse>()
                .HasOne(c => c.Course)
                .WithMany(s => s.Students)
                .HasForeignKey(fk => fk.CourseId);


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
