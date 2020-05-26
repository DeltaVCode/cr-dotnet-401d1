using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Technology
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Desc { get; set; }
    }
}
