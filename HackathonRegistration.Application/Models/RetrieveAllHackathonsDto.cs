using System.ComponentModel.DataAnnotations;

namespace HackathonRegistration.Application.Models
{
    public class RetrieveAllHackathonsDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Theme { get; set; }

        [Required]
        public DateTime EventDate { get; set; }
    }
}
