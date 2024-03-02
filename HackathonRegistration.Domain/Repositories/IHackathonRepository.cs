using HackathonRegistration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Domain.Repositories
{
    public interface IHackathonRepository
    {
        Task CreateHackathon(Hackathon hackathon);
        Task<List<Hackathon>> GetHackathons();
        Task<Hackathon?> GetHackathonById(int id);

        Task<Challenge> GetChallengeById(int challengeId);
    }
}
