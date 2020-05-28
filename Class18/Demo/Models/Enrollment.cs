using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Enrollment
    {
        public long StudentId { get; set; }
        public int CourseId { get; set; }

        // Navigation Properties
        [Required]
        public Student Student { get; set; }

        [Required]
        public Course Course { get; set; }
    }
}
