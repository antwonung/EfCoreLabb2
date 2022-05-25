using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace labb2Linq.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }
        public Grade Grade { get; set; }


        // En till många relation. En lärare kan ha en eller flera kurser,
        // En kurs kopplas till en lärare.
        public ICollection<Course> Courses { get; set; }
    }
}
