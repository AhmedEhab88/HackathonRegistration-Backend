using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Domain.Models
{
    public class Competitor
    {
        [Key]
        public int CompetitorID { get; set; }

        [ForeignKey("Team")]
        public int TeamID { get; set; }
        public Team Team { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }
    }
}
