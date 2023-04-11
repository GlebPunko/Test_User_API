using Application.Models;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserControlService _userInterface;

        public UserController(IUserControlService userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterAsync(Register user, CancellationToken cancellationToken)
        {
            var result = await _userInterface.RegisterAsync(user, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginAsync(Login login, CancellationToken cancellationToken)
        {
            var token = await _userInterface.LoginAsync(login, cancellationToken);

            return Ok(token);
        }

        [HttpGet]
        [Route("getCurrentUser")]
        [Authorize]
        public async Task<ActionResult<Response>> GetUserAsync(CancellationToken cancellationToken)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type.Equals(JwtService.UserId));
            
            if (userIdClaim is null || !Int32.TryParse(userIdClaim.Value, out int id))
            {
                return Unauthorized();
            }
            
            var user = await _userInterface.GetUserAsync(id,cancellationToken);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
