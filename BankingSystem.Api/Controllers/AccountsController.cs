using BankingSystem.Application.Features.Accounts.Commands.CreateAccount;
using BankingSystem.Application.Features.Accounts.Commands.DepositMoney;
using BankingSystem.Application.Features.Accounts.Commands.Transfer;
using BankingSystem.Application.Features.Accounts.Queries.GetDestinationAccount;
using BankingSystem.Application.Features.Accounts.Queries.GetSourceAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ISender _sender;
        public AccountsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateAccountCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(command, cancellationToken));
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(
            DepositMoneyCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(command, cancellationToken));
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(
            TransferCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(command, cancellationToken));
        }

        [HttpGet("source-account")]
        public async Task<IActionResult> GetSourceAccount(
            [FromQuery] GetSourceAccountQuery query,
            CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(query, cancellationToken));
        }

        [HttpGet("destination-account")]
        public async Task<IActionResult> GetDestinationAccount(
            [FromQuery] GetDestinationAccountQuery query,
            CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(query, cancellationToken));
        }

    }
}
