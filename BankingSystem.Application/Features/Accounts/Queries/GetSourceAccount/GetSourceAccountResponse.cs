using BankingSystem.Domain.Enums;

namespace BankingSystem.Application.Features.Accounts.Queries.GetSourceAccount
{
    public record GetSourceAccountResponse(string accountNumber,
        string fullName,
        decimal balance,
        EnAccountStatus accountStatus
        );
    
    
}
