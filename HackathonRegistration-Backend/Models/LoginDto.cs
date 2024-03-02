using System.ComponentModel.DataAnnotations;

namespace HackathonRegistration_Backend.Models
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
