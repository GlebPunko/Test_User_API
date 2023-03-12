using Application.Models;
using Application.Services.Interfaces;
using Domain.Entities;
using Infastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<User>> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            var user = await _userInterface.GetUserAsync(id,cancellationToken);

            return Ok(user);
        }
    }
}
