using HackathonRegistration.Application.Services.Interfaces;
using HackathonRegistration.Domain.Models;
using HackathonRegistration.Domain.Repositories;

namespace HackathonRegistration.Application.Services.Implementations
{
    public class HackathonService : IHackathonService
    {
        private readonly IHackathonRepository _hackathonRepository;

        public HackathonService(IHackathonRepository hackathonRepository)
        {
            _hackathonRepository = hackathonRepository;
        }

        public async Task CreateHackathon(Hackathon hackathon)
        {
            await _hackathonRepository.CreateHackathon(hackathon);
        }

        public async Task<List<Hackathon>> GetHackathons()
        {
            return await _hackathonRepository.GetHackathons();
        }

        public async Task<Hackathon?> GetHackathonById(int id)
        {
            var hackathon = await _hackathonRepository.GetHackathonById(id);

            return hackathon;
        }
    }
}