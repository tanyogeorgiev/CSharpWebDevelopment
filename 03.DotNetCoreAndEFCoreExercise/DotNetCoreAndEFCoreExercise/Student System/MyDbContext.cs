using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{

    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Data;

   public class MyDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<License> Lecenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

            builder.UseSqlServer("Server=(local)\\tg; Database=EFCoreStudentSystem;Trusted_Connection=True");
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(pk => new { pk.StudentId, pk.CourseId });
            builder
            .Entity<StudentCourse>()
            .HasOne(h => h.Student)
            .WithMany(m => m.Courses)
            .HasForeignKey(fk => fk.StudentId);
             
            builder
            .Entity<StudentCourse>()
            .HasOne(h => h.Course)
            .WithMany(m => m.Students)
            .HasForeignKey(fk => fk.CourseId);

            builder
                .Entity<Course>()
                .HasMany(m => m.Resources)
                .WithOne(o => o.Course)
                .HasForeignKey(fk => fk.CourseId);

            builder
               .Entity<Course>()
               .HasMany(m => m.Homeworks)
               .WithOne(o => o.Course)
               .HasForeignKey(fk => fk.CourseId);


            builder
               .Entity<Student>()
               .HasMany(m => m.Homeworks)
               .WithOne(o => o.Student)
               .HasForeignKey(fk => fk.StudetnId);

            builder
                .Entity<Resource>()
                .HasMany(r => r.Licenses)
                .WithOne(o => o.Resource)
                .HasForeignKey(fk => fk.ResourceId);
        }
    }
}