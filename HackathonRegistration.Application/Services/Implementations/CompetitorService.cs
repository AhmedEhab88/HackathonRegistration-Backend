using HackathonRegistration.Application.Models;
using HackathonRegistration.Application.Services.Interfaces;
using HackathonRegistration.Domain.Models;
using HackathonRegistration.Domain.Repositories;
using System.Runtime.Versioning;

namespace HackathonRegistration.Application.Services.Implementations
{
    public class CompetitorService : ICompetitorService
    {
        private readonly ICompetitorRepository _competitorRepository;

        public CompetitorService(ICompetitorRepository competitorRepository)
        {
            _competitorRepository = competitorRepository;
        }

        public async Task RegisterCompetitor(Team team)
        {
            await _competitorRepository.Register(team);
        }
    }
}