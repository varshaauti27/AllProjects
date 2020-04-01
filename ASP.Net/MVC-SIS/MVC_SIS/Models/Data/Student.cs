using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter GPA")]
        [Range(0,4.0,ErrorMessage ="Please enter GPA between(0-4)")]
        public Nullable<decimal> GPA { get; set; }

        public Address Address { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}