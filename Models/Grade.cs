using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace labb2Linq.Models
{
    public class Grade
    {
       
        [Key]
        public string GradeName { get; set; }
        [Required]
        public string Section  { get; set; }
        //En till en relation, lärare till klass.
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        // En till många relation, en student kan gå i en klass
        // En klass kan kopplas til en eller flera studenter.
        public ICollection<Student> Students { get; set; }
    }
}
