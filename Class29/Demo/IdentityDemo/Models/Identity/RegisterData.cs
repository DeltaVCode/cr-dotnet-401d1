using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Models.Identity
{
    public class RegisterData
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string[] Roles { get; set; }
    }
}
