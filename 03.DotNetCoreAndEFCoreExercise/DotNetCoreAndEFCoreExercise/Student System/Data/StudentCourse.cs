using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.Data
{
  public  class StudentCourse
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
