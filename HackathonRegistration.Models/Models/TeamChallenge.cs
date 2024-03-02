using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Models.Models
{
    public class TeamChallenge
    {
        public int TeamID { get; set; }
        public Team Team { get; set; }

        public int ChallengeID { get; set; }
        public Challenge Challenge { get; set; }
    }
}
