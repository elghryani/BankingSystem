using MediatR;
namespace BankingSystem.Application.Features.Accounts.Commands.CreateAccount
{
    public record CreateAccountCommand(Guid customerId) : IRequest<CreateAccountResponse>;
    
}
