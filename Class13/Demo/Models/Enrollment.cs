using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Enrollment
    {
        public long Id { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        public Course Course { get; set; }
    }
}
