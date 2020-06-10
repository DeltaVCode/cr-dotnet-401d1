using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Models.Identity
{
    public class UpdateUserData
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
