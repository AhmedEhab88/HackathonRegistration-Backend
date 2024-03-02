using HackathonRegistration.Application.Models;
using HackathonRegistration.Application.Services.Interfaces;
using HackathonRegistration.Domain.Models;
using HackathonRegistration.Domain.Repositories;
using System.Runtime.Versioning;

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

        public async Task<List<RetrieveAllHackathonsDto>> GetHackathons()
        {
            var hackathons = await _hackathonRepository.GetHackathons();

            var hackathonDtos = hackathons.Select(h => new RetrieveAllHackathonsDto
            {
                Name = h.Name,
                Theme = h.Theme,
                EventDate = h.EventDate
            }).ToList();

            return hackathonDtos;
        }

        public async Task<RetrieveHackathonByIdDto?> GetHackathonById(int id)
        {
            var hackathon = await _hackathonRepository.GetHackathonById(id);

            if(hackathon == null)
                return null;

            var hackathonDto = new RetrieveHackathonByIdDto
            {
                HackathonId = hackathon.HackathonID,
                Name = hackathon.Name,
                Theme = hackathon.Theme,
                RegistrationStartDate = hackathon.RegistrationStartDate,
                RegistrationEndDate = hackathon.RegistrationEndDate,
                EventDate = hackathon.EventDate,
                MaximumTeamSize = hackathon.MaximumTeamSize,
                MaximumNumberOfTeams = hackathon.MaximumNumberOfTeams,
                Challenges = hackathon.Challenges.Select(c => new ChallengeDto
                {
                    ChallengeId = c.ChallengeID,
                    Title = c.Title
                }).ToList()
            };

            return hackathonDto;
        }
    }
}