using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int? Difficulty { get; set; }

        public string AssignedTo { get; set; }

        public bool Completed { get; set; }
    }
}
