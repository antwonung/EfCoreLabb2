using System;
using System.Collections.Generic;
using System.Text;

namespace labb2Linq.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student  { get; set; }
        public string CourseName { get; set; }
        public Course Course { get; set; }
    }
}
