using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ManyToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new MyDbContext())
            //{
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();

            //    var course = new Course { Name = "C# Web Dev"};

            //    for (int i = 0; i < 10; i++)
            //    {
            //        course.Students.Add(new StudentCourse { Student = new Student { Name = $"Student {i}" } });
            //    }

            //    db.Add(course);
            //    db.SaveChanges();
            //}

            var courseid = 1;
            using (var db = new MyDbContext())
            {
                var courses = db.Courses.Include(p => p.Students).Where(p => p.Id == courseid);
                    

            }
            
        }
    }
}
