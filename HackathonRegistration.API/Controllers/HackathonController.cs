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
    [Route("api/hackathons")]
    public class HackathonController : ControllerBase
    {
        private readonly ICompetitorService _hackathonService;

        public HackathonController(ICompetitorService hackathonService)
        {
            _hackathonService = hackathonService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateHackathon(HackathonDto model)
        {
            try
            {
                var challenges = model.Challenges.Select(c => new Challenge
                {
                    Title = c.Title,
                    Teams = new List<Team>(),
                    Hackathons = new List<Hackathon>()
                }).ToList();

                // Convert the model to a Hackathon entity
                var hackathon = new Hackathon
                {
                    Name = model.Name,
                    Theme = model.Theme,
                    RegistrationStartDate = model.RegistrationStartDate,
                    RegistrationEndDate = model.RegistrationEndDate,
                    EventDate = model.EventDate,
                    MaximumTeamSize = model.MaximumTeamSize,
                    MaximumNumberOfTeams = model.MaximumNumberOfTeams,
                    Teams = new List<Team>(), // initialize with empty list of teams
                    Challenges = challenges
                };

                // Use your save method to create the hackathon in the database
                await _hackathonService.CreateHackathon(hackathon);

                return Ok();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin,competitor")]
        public async Task<IActionResult> GetHackathons()
        {
            try
            {
                var hackathons = await _hackathonService.GetHackathons();

                return Ok(hackathons);
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,competitor")]
        public async Task<IActionResult> GetHackathon(int id)
        {
            try
            {
                var hackathon = await _hackathonService.GetHackathonById(id);

                if (hackathon == null)
                    return NotFound();

                return Ok(hackathon);
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}