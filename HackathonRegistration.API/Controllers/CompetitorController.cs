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
        public async Task<IActionResult> RegisterCompetitor([FromBody] CompetitorRegisterRequest request)
        {
            try
            {

                await _competitorService.RegisterCompetitor(request);
                
                return Ok();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}