namespace BankingSystem.Application.Features.Accounts.Queries.GetSourceAccount
{
    public record GetSourceAccountResponse(string accountNumber,
        string fullName,
        decimal Balance,
        string AccountStatus
        );
    
    
}
