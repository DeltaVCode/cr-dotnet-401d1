using System.Collections.Generic;

namespace Demo.Models.Api
{
    public class StudentDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // no BirthDate

        public List<CourseDTO> Courses { get; set; }
    }
}
