using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Models.Identity
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
