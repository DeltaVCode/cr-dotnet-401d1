using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Api
{
    public class CreateCourse
    {
        [Required]
        public string CourseCode { get; set; }

        public int TechnologyId { get; set; }

        public decimal Price { get; set; }
    }
}
