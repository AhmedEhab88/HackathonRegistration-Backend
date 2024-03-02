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
        private readonly IHackathonRepository _hackathonRepository;

        public CompetitorService(ICompetitorRepository competitorRepository, IHackathonRepository hackathonRepository)
        {
            _competitorRepository = competitorRepository;
            _hackathonRepository = hackathonRepository;
        }

        public async Task RegisterCompetitor(CompetitorRegisterRequest request)
        {

            var challengeRequested = await _hackathonRepository.GetChallengeById(request.ChallengeId);

            // Create the team
            var team = new Team
            {
                TeamName = request.TeamName,
                HackathonID = request.HackathonId,
                Challenges = new List<Challenge> { challengeRequested }
            };


            team.Competitors = new List<Competitor>();

            // Register each competitor in the team
            foreach (var competitorDto in request.Competitors)
            {
                var competitor = new Competitor
                {
                    Name = competitorDto.Name,
                    Email = competitorDto.Email,
                    Mobile = competitorDto.Mobile
                };

                team.Competitors.Add(competitor);
            }

            await _competitorRepository.Register(team);
        }
    }
}