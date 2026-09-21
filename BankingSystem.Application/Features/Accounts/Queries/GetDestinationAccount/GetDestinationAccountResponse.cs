
using BankingSystem.Domain.Enums;

namespace BankingSystem.Application.Features.Accounts.Queries.GetDestinationAccount
{
    public record GetDestinationAccountResponse(string accountNumber,
        string fullName,
        EnAccountStatus AccountStatus);
    
    
}
