using BankingSystem.Application.Features.Auth.Commands.Login;
using BankingSystem.Application.Features.Auth.Queries.GetCurrentUser;
using BankingSystem.Infrastructure.Security.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BankingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly JwtSettings _jwtSettings;
        public AuthController(IMediator mediator, IOptions<JwtSettings> jwtSettings)
        {
            _sender = mediator;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _sender.Send(command, cancellationToken);

            Response.Cookies.Append(
                "accessToken",
                user.accessToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes)
                });

            return Ok(new
            {
                UserName = user.userName,
                PhoneNumber = user.phoneNumber,
                Status = user.status.ToString(),
            });

        }


      
        [HttpGet("me")]
        public async Task<IActionResult> Me(CancellationToken cancellationToken)
        {
            var user = await _sender.Send(new GetCurrentUserQuery(), cancellationToken);

            return Ok(user);
        }
    }
}
