using BankingSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public IAccountRepository AccountRepository => new AccountRepository(_appDbContext);

        public ITransactionRepository TransactionRepository => throw new NotImplementedException();

        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_appDbContext);

        public IKycRepository KycRepository => new KycRepository(_appDbContext);

        public ICustomerRepository CustomerRepository => new CustomerRepository(_appDbContext);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           return await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
