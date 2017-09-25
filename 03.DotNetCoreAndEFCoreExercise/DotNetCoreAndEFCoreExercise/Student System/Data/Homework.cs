
namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Homework
    {
        //id, content, content-type (application/pdf/zip), submission date

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int StudetnId { get; set; }

        public Student Student { get; set; }
    }
}
