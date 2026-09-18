using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<bool> ExistsByPhoneNumberAsync(string phoneNumber);
    }
}
