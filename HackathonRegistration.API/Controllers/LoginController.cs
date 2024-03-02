using HackathonRegistration.API.Models;
using HackathonRegistration.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackathonRegistration.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var token = await _loginService.Login(model.Username, model.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
