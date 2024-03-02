using HackathonRegistration.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Infrastructure
{
    public class HackathonRegistrationDbContext : DbContext
    {
        public HackathonRegistrationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Hackathon> Hackathons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<HackathonChallenge> HackathonChallenges { get; set; }
        public DbSet<TeamChallenge> TeamChallenges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<HackathonChallenge>()
                .HasKey(hc => new { hc.HackathonID, hc.ChallengeID });

            modelBuilder.Entity<Hackathon>()
                .HasMany(hc => hc.Challenges)
                .WithMany(h => h.Hackathons)
                .UsingEntity<HackathonChallenge>();


            modelBuilder.Entity<TeamChallenge>()
                .HasKey(tc => new { tc.TeamID, tc.ChallengeID });

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Challenges)
                .WithMany(c => c.Teams)
                .UsingEntity<TeamChallenge>();
        }
    }
}
