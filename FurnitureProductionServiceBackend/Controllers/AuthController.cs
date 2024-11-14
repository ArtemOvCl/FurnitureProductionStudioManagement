using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Repositories;
using System.Threading.Tasks;

namespace FurnitureProductionServiceBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var authResponse = await _authRepository.LoginAsync(loginDto);
            if (!authResponse.Success)
            {
                return BadRequest(new { errors = authResponse.Errors });
            }

            return Ok(new { Token = authResponse.Token });
        }
    }
}
