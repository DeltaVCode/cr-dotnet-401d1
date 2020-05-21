using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public decimal Price { get; set; }

        // Reference to another table!
        [Required]
        public Technology Technology { get; set; }
        public int TechnologyId { get; set; }
    }
}
