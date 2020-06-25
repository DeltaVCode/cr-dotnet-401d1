using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Api
{
    public class RegisterData : LoginData
    {
        [Required]
        public string Email { get; set; }

        public string[] Roles { get; set; }
    }
}