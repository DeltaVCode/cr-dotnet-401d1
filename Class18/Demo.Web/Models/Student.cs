using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Web.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Tuition Cost")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? Tuition { get; set; }

        // no BirthDate

        public List<CourseSummary> Courses { get; set; }
    }
}
