namespace Demo.Models.Api
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string CourseCode { get; set; }

        // No Price

        // No Technology object, just the Name
        public string TechnologyName { get; set; }
    }
}
