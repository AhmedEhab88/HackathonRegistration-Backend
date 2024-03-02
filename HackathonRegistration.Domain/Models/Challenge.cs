using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Domain.Models
{
    public class Challenge
    {
        [Key]
        public int ChallengeID { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Hackathon> Hackathons { get; set; }
    }
}
