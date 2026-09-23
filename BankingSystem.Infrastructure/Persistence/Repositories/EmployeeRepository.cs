using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext)  : base(appDbContext){ }
        public async Task<bool> ExistsByPhoneNumberAsync(string phoneNumber)
        {
            return await _appDbContext.Employees.AnyAsync(e => e.PhoneNumber == phoneNumber);
        }

        public async Task<bool> ExistsByUserNameAsync(string UserName)
        {
            return await _appDbContext.Employees.AnyAsync(e => e.UserName == UserName);
        }

       

        public async Task<Employee?> FindByUserNameAsync(string userName)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(e => e.UserName == userName);
        }
    }
}
