using HackathonRegistration.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace HackathonRegistration.API.Models
{
    public class HackathonDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Theme { get; set; }

        [Required]
        public DateTime RegistrationStartDate { get; set; }

        [Required]
        public DateTime RegistrationEndDate { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public int MaximumTeamSize { get; set; }

        [Required]
        public int MaximumNumberOfTeams { get; set; }

        public List<ChallengeDto> Challenges { get; set; }
    }
}
