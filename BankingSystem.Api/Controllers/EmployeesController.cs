using BankingSystem.Application.Features.Employee.Commands.CreateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BankingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _sender;

        public EmployeesController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost]
        public async Task<IActionResult> Create(
           CreateEmployeeCommand command,
           CancellationToken cancellationToken)
        {
            var employeeId = await _sender.Send(command, cancellationToken);

            return Ok(employeeId);
        }
    }
}
