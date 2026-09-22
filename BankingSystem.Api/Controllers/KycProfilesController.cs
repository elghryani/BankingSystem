using BankingSystem.Application.Features.KycProfiles.Commands.CreateKycProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KycProfilesController : ControllerBase
    {
        private readonly ISender _sender;
        public KycProfilesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateKycProfileCommand command,CancellationToken cancellationToken)
        {
            var kycProfileId = await _sender.Send(command, cancellationToken);
            return Ok(kycProfileId);
        }
    }
}
