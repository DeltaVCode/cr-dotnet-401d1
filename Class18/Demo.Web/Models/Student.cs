using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Demo.Web.Models
{
    public class Student
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [Display(Name = "Tuition Cost")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? Tuition { get; set; }

        // no BirthDate

        public List<CourseSummary> Courses { get; set; }
    }
}
