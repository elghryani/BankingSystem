using MediatR;
namespace BankingSystem.Application.Features.Accounts.Commands.Transfer
{
    public record TransferCommand(string fromAccountNumber,
        string toAccountNumber,
        decimal amount) : IRequest<bool>;
    
    
}
