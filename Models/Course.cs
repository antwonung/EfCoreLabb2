using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace labb2Linq.Models
{
    public class Course
    {
     
        [Key]
        public string CourseName { get; set; }
       
        [Required]
        public DateTime CourseStart { get; set; }
        [Required]
        public DateTime CourseEnd { get; set; }
        
        // En till många relation. En lärare kan ha en eller flera kurser,
        // En kurs kopplas till en lärare.
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        // Många till många relation. kurs till elev
        public ICollection<StudentCourse> StudentCourses { get; set; }



    }
}
