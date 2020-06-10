using System;
using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Models.Identity
{
    // Default Id is a string
    // Optional: specify TKey, e.g. <int>
    public class BlogUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
