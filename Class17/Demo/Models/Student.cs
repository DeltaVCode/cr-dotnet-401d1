using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Student
    {
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        // Navigation Property
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
