using Authentication.Application.Features.Auth.Commands.Login;
using Authentication.Application.Features.Auth.Queries.Ping;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Api;

namespace Authentication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping(CancellationToken ct)
        {
            var result = await _sender.Send(new PingQuery(), ct);
            return result.ToActionResult(this);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command, CancellationToken ct)
        {
            var result = await _sender.Send(command, ct);
            return result.ToActionResult(this);
        }
    }
}
