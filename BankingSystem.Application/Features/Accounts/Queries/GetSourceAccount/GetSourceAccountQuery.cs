using MediatR;
namespace BankingSystem.Application.Features.Accounts.Queries.GetSourceAccount
{
    public record GetSourceAccountQuery(string accountNumber) : IRequest<GetSourceAccountResponse>;
    
    
}
