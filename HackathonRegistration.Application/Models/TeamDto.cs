using System.ComponentModel.DataAnnotations;

namespace HackathonRegistration.Application.Models
{
    public class CompetitorRegisterRequest
    {
        [Required]
        public string TeamName { get; set; }

        [Required]
        public List<CompetitorDto> Competitors { get; set; }

        [Required]
        public int HackathonId { get; set; }

        [Required]
        public int ChallengeId { get; set; }
    }

    public class CompetitorDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }
    }
}
