using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Contents { get; set; }

        public string CreatedByUserId { get; set; }
        public DateTime CreatedByTimestamp { get; set; }
        public string ModifiedByUserId { get; set; }
        public DateTime? ModifiedByTimestamp { get; set; }
    }

    public class PostDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Contents { get; set; }

        public string CreatedBy { get; set; }
    }
}
