using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Data
{
    public class Student
    {
        // id, name, phone number(optional), registration date, birthday (optional)
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? BirthDay { get; set; }

        public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();

        public List<Homework> Homeworks { get; set; } = new List<Homework>();



    }

}