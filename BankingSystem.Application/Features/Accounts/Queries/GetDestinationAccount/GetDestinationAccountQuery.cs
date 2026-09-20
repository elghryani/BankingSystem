using MediatR;
namespace BankingSystem.Application.Features.Accounts.Queries.GetDestinationAccount
{
    public record GetDestinationAccountQuery(string accountNumber) : IRequest<GetDestinationAccountResponse>;
    
    
}
