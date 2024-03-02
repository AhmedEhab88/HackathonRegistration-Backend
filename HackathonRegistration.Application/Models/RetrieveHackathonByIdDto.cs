using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Application.Models
{
    public class RetrieveHackathonByIdDto
    {
        public int HackathonId { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public DateTime EventDate { get; set; }
        public int MaximumTeamSize { get; set; }
        public int MaximumNumberOfTeams { get; set; }
        public List<ChallengeDto> Challenges { get; set; }
    }
}
