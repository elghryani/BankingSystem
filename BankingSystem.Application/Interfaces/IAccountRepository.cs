using BankingSystem.Application.Features.Accounts.Queries.GetSourceAccount;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<bool> ExistsByAccountNumberAsync(string accountNumber);
        Task<GetSourceAccountResponse> GetSourceAccountAsync(string accountNumber);
    }
}
