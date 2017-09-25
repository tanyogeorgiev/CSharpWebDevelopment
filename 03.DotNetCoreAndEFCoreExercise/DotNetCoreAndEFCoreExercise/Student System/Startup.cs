

using StudentSystem;
using StudentSystem.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Student_System
{
    public class Program
    {
        public static void Main()
        {

            using (var db = new MyDbContext())
            {

                //db.Database.Migrate();
                //DbSeed(db);
                // DbLicenseSeed(db);

                // PrintStudentsWithHomeworks(db);
                // PrintCoursesAndResources(db);
                // PrintCoursesWithMoreThanFiveResource(db);
                // PrintCourseActiveOnADate(db);
                // PrintStudentsWithPrices(db);
                // PrintCourseWithResourcesAndLicense(db);
                //PrintAllStudentsWithCoursesAndResourcesAndLicenses(db);


            }


        }

        private static void PrintAllStudentsWithCoursesAndResourcesAndLicenses(MyDbContext db)
        {
            var result = db
               .Students
               .Select(s => new
               {
                   s.Name,
                   Courses = s.Courses.Select(c => new
                   {
                       c.Course.Name,
                       Resources = c.Course.Resources.Select(r => new
                       {
                           r.Name,
                           Licenses = r.Licenses.Select(l => l.Name)
                       })
                   })
               });

            foreach (var student in result)
            {
                Console.WriteLine();
                Console.WriteLine(new String('-', 35));
                               Console.WriteLine($"---#### {student.Name} ####---");
                Console.WriteLine(new String('-', 35));
                Console.WriteLine();

                foreach (var courses in student.Courses)
                {
                    Console.WriteLine($"|=>{courses.Name}##");

                    foreach (var resources in courses.Resources)
                    {
                        Console.WriteLine($"|-|=> {resources.Name}");

                        foreach (var license in resources.Licenses)
                        {
                            Console.WriteLine($"| |-|=> {license}");
                        }
                     
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void PrintCourseWithResourcesAndLicense(MyDbContext db)
        {
            var result = db
                 .Courses
                 .OrderByDescending(c => c.Resources.Count)
                 .ThenBy(c => c.Name)
                 .Select(s => new
                 {
                     s.Name,
                     Resources = s
                     .Resources
                     .OrderByDescending(r => r.Licenses.Count)
                     .ThenBy(r => r.Name)
                     .Select(r => new
                     {
                         r.Name,
                         Licenses = r.Licenses.Select(l => l.Name)
                     })
                 }).ToList();

            foreach (var course in result)
            {
                Console.WriteLine(course.Name);

                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"---====={resource.Name}====-----");

                    foreach (var r in resource.Licenses)
                    {
                        Console.WriteLine($"...:::{r}");
                    }
                }
            }
        }

        private static void PrintStudentsWithPrices(MyDbContext db)
        {
            var result = db
                .Students
                .Where(s => s.Courses.Any())
                .Select(s => new
                {
                    s.Name,
                    s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Course.Price),
                    AvaragePrice = s.Courses.Average(c => c.Course.Price)

                })
                .OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.Count)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name} - {student.Count} - {student.TotalPrice} - {student.AvaragePrice}");

            }

        }

        private static void PrintCourseActiveOnADate(MyDbContext db)
        {
            var date = DateTime.Now.AddDays(25);

            var result = db
                .Courses
                .Where(c => c.StartDate < date && date < c.EndDate)
                .Select(s => new
                {
                    s.Name,
                    s.StartDate,
                    s.EndDate,
                    Duration = s.EndDate.Subtract(s.StartDate).TotalDays,
                    Students = s.Students.Count

                })
                .OrderByDescending(c => c.Students)
                .ThenByDescending(c => c.Duration)
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name} : {course.StartDate.ToShortDateString()} - {course.EndDate.ToShortDateString()}  ");
                Console.WriteLine($"------Duration: {course.Duration}");
                Console.WriteLine($"------Students: {course.Students}");
            }
        }

        private static void PrintCoursesWithMoreThanFiveResource(MyDbContext db)
        {
            var result = db
                 .Courses
                 .Where(c => c.Resources.Count > 5)
                 .OrderByDescending(o => o.Resources.Count)
                 .ThenByDescending(tb => tb.StartDate)
                 .Select(s => new
                 {
                     s.Name,
                     ResourceCount = s.Resources.Count
                 });

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name} - {course.ResourceCount}");
            }
        }

        private static void PrintCoursesAndResources(MyDbContext db)
        {
            var result = db
                 .Courses
                 .OrderBy(ob => ob.StartDate)
                 .ThenBy(sb => sb.EndDate)
                 .Select(s => new
                 {
                     s.Name,
                     s.Description,
                     Resources = s.Resources.Select(r => new
                     {
                         r.Name,
                         r.URL,
                         r.ResourceType
                     })
                 }).ToList();

            foreach (var course in result)
            {

                Console.WriteLine($"{course.Name} - {course.Description}");

                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"{resource.Name} - {resource.ResourceType} - {resource.URL}");
                }
            }
        }

        private static void PrintStudentsWithHomeworks(MyDbContext db)
        {
            var result = db.Students.Select(s => new
            {
                s.Name,
                Homeworks = s.Homeworks.Select(h => new
                {
                    h.Content,
                    h.ContentType
                })
            })
            .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
                foreach (var hw in item.Homeworks)
                {
                    Console.WriteLine($"----{hw.Content} - {hw.ContentType}");
                }
            }


        }

        private static void DbSeed(MyDbContext db)
        {
            var totalStudents = 25;
            var totalCourses = 10;
            using (db)
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var currDate = DateTime.Now;

                //Students
                Console.WriteLine("Adding Students");
                for (int i = 0; i < totalStudents; i++)
                {
                    db.Add(new Student
                    {
                        Name = $"Student {i}",
                        RegistrationDate = currDate.AddDays(i),
                        BirthDay = currDate.AddYears(-20 - i).AddDays(i),
                        PhoneNumber = $"Random Phone {i}"
                    });
                    if (i % 2 == 0)
                    {
                        Console.Write('.');
                    }
                }
                db.SaveChanges();

                //COurses

                Console.WriteLine("Adding Courses");
                var addedCourses = new List<Course>();
                for (int i = 0; i < totalCourses; i++)
                {
                    var course = new Course
                    {
                        Name = $"Course {i}",
                        Description = $"Course details {i}",
                        Price = 100 * i,
                        StartDate = currDate.AddDays(i),
                        EndDate = currDate.AddDays(i + 20)

                    };

                    db.Courses.Add(course);
                    addedCourses.Add(course);
                    if (i % 1 == 0)
                    {
                        Console.Write('.');
                    }
                }
                db.SaveChanges();

                var random = new Random();
                var studentIds = db.Students.Select(s => s.Id).ToList();

                //Students in Courses

                Console.WriteLine("Adding Student in Courses");
                for (int i = 0; i < totalCourses; i++)
                {
                    var currentCourse = addedCourses[i];
                    var studentsInCourse = random.Next(2, totalStudents / 2);

                    for (int j = 0; j < studentsInCourse; j++)
                    {
                        var studentId = studentIds[random.Next(0, studentIds.Count)];

                        if (!currentCourse.Students.Any(s => s.StudentId == studentId))
                        {
                            currentCourse.Students.Add(new StudentCourse
                            {
                                StudentId = studentId,
                            });
                        }
                        else
                        {
                            j--;
                        }
                    }

                    var resourcesInCourse = random.Next(2, 20);
                    var types = new[] { 0, 1, 2, 999 };

                    for (int j = 0; j < resourcesInCourse; j++)
                    {
                        currentCourse.Resources.Add(new Resource
                        {
                            Name = $"Resource {i} {j}",
                            URL = $"URL {i} {j}",
                            ResourceType = (ResourceType)types[random.Next(0, types.Length)]
                        });
                    }


                    if (i % 2 == 0)
                    {
                        Console.Write('.');
                    }
                }
                db.SaveChanges();


                //Homeworks
                Console.WriteLine("Adding Homeworks");
                for (int i = 0; i < totalCourses; i++)
                {
                    var currentCourse = addedCourses[i];
                    var studentinCourseIds = currentCourse.Students.Select(s => s.StudentId).ToList();

                    for (int j = 0; j < studentinCourseIds.Count; j++)
                    {
                        var totalHomeworks = random.Next(2, 5);
                        for (int k = 0; k < totalHomeworks; k++)
                        {
                            db.Homeworks.Add(new Homework
                            {
                                Content = $"Content Homework {i}",
                                SubmissionDate = currDate.AddDays(-i),
                                ContentType = ContentType.PDF,
                                StudetnId = studentinCourseIds[j],
                                CourseId = currentCourse.Id

                            });
                        }

                    }

                }

                db.SaveChanges();


            }
        }

        private static void DbLicenseSeed(MyDbContext db)
        {
            var random = new Random();
            var resourceIds = db
                 .Resources
                 .Select(o => o.Id)
                 .ToList();

            for (int i = 0; i < resourceIds.Count; i++)
            {
                var totalLicenses = random.Next(1, 4);
                for (int j = 0; j < totalLicenses; j++)
                {
                    db.Lecenses.Add(new License
                    {
                        Name = $"License {j}",
                        ResourceId = resourceIds[i]
                    });
                }

            }

            db.SaveChanges();
        }
    }
}
