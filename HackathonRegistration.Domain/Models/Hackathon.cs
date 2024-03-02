using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Domain.Models
{
    public class Hackathon
    {
        [Key]
        public int HackathonID { get; set; }

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

        public ICollection<Team> Teams { get; set; }

        public ICollection<Challenge> Challenges { get; set; }
    }
}
