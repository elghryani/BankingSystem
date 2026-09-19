namespace BankingSystem.Application.Interfaces
{
    public interface IUnitOfWork
    {
        
        IAccountRepository AccountRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IKycRepository KycRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
