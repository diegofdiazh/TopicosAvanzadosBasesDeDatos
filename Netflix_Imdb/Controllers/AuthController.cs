using Microsoft.AspNetCore.Mvc;
using Netflix_Imdb.Application.Models;
using Netflix_Imdb.Application.Services.Interfaces;

namespace Netflix_Imdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _authService.Authenticate(model.Username, model.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }

 
}

