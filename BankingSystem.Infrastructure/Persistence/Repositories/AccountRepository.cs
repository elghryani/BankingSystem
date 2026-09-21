using BankingSystem.Application.Features.Accounts.Queries.GetDestinationAccount;
using BankingSystem.Application.Features.Accounts.Queries.GetSourceAccount;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BankingSystem.Infrastructure.Persistence.Repositories
{
    internal class AccountRepository : Repository<Account>, IAccountRepository
    {

        public AccountRepository(AppDbContext appDbContext) : base(appDbContext) { }
       

        public async Task<bool> ExistsByAccountNumberAsync(string accountNumber)
        {
            return await _appDbContext.Accounts.AnyAsync(x => x.AccountNumber == accountNumber);
        }

        public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
        {
            return await _appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
        }

        public async Task<GetDestinationAccountResponse?> GetDestinationAccount(string accountNumber)
        {
            return await _appDbContext.Accounts
         .Where(x => x.AccountNumber == accountNumber)
         .Select(x => new GetDestinationAccountResponse(
             x.AccountNumber,
             x.Customer.FirstName + " " + x.Customer.LastName,
             x.Status
         ))
         .FirstOrDefaultAsync();

        }

        public async Task<GetSourceAccountResponse?> GetSourceAccountAsync(string accountNumber)
        {
            return await _appDbContext.Accounts
                .Where(x => x.AccountNumber == accountNumber)
                .Select(x => new GetSourceAccountResponse(x.AccountNumber,
                x.Customer.FirstName + " " + x.Customer.LastName,
                x.Balance,
                x.Status
                )).FirstOrDefaultAsync();
        }
    }
}
