using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace labb2Linq.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string GradeName { get; set; }
        public Grade Grade { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
