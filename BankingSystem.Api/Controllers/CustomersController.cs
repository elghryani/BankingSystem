using BankingSystem.Application.Features.Customers.Commands.ActivateCustomer;
using BankingSystem.Application.Features.Customers.Commands.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ISender _sender;

        public CustomersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command,CancellationToken cancellationToken)
        {
            var customerId = await _sender.Send(command, cancellationToken);
            return Ok(customerId);
        }

        [HttpPatch("{id}/activate")]
        public async Task<IActionResult> ActivateCustomer(Guid id, CancellationToken cancellationToken)
        {
            var command = new ActivateCustomerCommand(id);

            var customer = await _sender.Send(command, cancellationToken);

            return Ok(customer);
        }


    }
}
