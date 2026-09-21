using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> ExistsByPhoneNumberAsync(string phoneNumber);
        Task<Customer?> GetByIdWithKycAsync(Guid? CustomerId);
    }
}
