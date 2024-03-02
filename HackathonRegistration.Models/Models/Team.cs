using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Models.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        [Required]
        public string TeamName { get; set; }

        public int HackathonID { get; set; }
        public Hackathon Hackathon { get; set; }

        public ICollection<Competitor> Competitors { get; set; }

        public ICollection<Challenge> Challenges { get; set; }
    }
}
