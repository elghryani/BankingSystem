using MediatR;
namespace BankingSystem.Application.Features.Accounts.Commands.DepositMoney
{
    public record DepositMoneyCommand(string accountNumber, decimal amount) : IRequest<bool>;
    
    
}
