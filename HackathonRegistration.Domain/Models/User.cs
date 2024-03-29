﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Domain.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }
    }
}
