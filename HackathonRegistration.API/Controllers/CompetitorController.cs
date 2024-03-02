using HackathonRegistration.Application.Models;
using HackathonRegistration.Application.Services.Interfaces;
using HackathonRegistration.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackathonRegistration.API.Controllers
{
    [ApiController]
    [Route("api/competitors")]
    public class CompetitorController : ControllerBase
    {
        private readonly ICompetitorService _competitorService;

        public CompetitorController(ICompetitorService competitorService)
        {
            _competitorService = competitorService;
        }

        [HttpPost]
        [Authorize(Roles = "competitor")]
        public Task<IActionResult> RegisterCompetitor([FromBody] CompetitorRegisterRequest request)
        {
            // Create the team
            var team = new Team
            {
                TeamName = request.TeamName,
                HackathonID = request.HackathonId
            };

            var teamChallenge = new TeamChallenge
            {

            };

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

            _competitorService.RegisterCompetitor(team);

            return Ok("The team is registered successfully");
        }
    }
}