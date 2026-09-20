using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<bool> ExistsByAccountNumberAsync(string accountNumber);
    }
}
