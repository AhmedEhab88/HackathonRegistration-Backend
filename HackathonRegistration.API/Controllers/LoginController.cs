using HackathonRegistration.Application.Models;
using HackathonRegistration.Application.Services.Interfaces;
using HackathonRegistration.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackathonRegistration.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var token = await _loginService.Login(model.Username, model.Password);
            if (token == null)
                return NotFound("User does not exist.");

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            try
            {
                // Hash the password
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                // Create a new Competitor instance
                var competitor = new Competitor
                {
                    Name = model.Name,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Username = model.Username,
                    Password = hashedPassword
                };

                // Use your save method to persist the user to the database
                await _loginService.Register(competitor);

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
