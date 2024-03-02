using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Models.Models
{
    public class HackathonChallenge
    {
        public int HackathonID { get; set; }
        public Hackathon Hackathon { get; set; }

        public int ChallengeID { get; set; }
        public Challenge Challenge { get; set; }
    }
}
