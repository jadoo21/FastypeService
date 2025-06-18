using FastypeService.Models.DTOs;
using FastypeService.Services;
using FastypeService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FastypeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : Controller
    {
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupDto signupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authService.SignupAsync(signupDto);

            if (!result.Success)
            {
                return Conflict(result);
            }

            return Ok(result);
        }
    }
}
