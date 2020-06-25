using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Api
{
    public class RegisterData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}