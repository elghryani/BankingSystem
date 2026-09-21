using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : Repository<Transaction> , ITransactionRepository
    {
        public TransactionRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
