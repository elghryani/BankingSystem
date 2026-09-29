using BankingSystem.Application.Features.Customers.Queries.GetPendingCustomers;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BankingSystem.Domain.Enums;


namespace BankingSystem.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext appDbContext)
       : base(appDbContext)
        {
        }

        public async Task<bool> ExistsByPhoneNumberAsync(
            string phoneNumber)
        {
          return await _appDbContext.Customers.AnyAsync(x => x.PhoneNumber == phoneNumber);
        }
        public async Task<Customer?> GetByIdWithKycAsync(Guid? CustomerId)
        {
            return await _appDbContext.Customers
                        .Include(x => x.Profile)
                        .FirstOrDefaultAsync(x => x.Id == CustomerId);
        }

        public async Task<List<GetPendingCustomersResponse>> GetPendingCustomersAsync()
        {
            return await _appDbContext.Customers
                        .Where(x => x.Status == EnUserStatus.Pending)
                        .Select(x => new GetPendingCustomersResponse(
                            x.Id,
                            x.FirstName + " " + x.LastName,
                            x.PhoneNumber,
                            x.Status
                            )).ToListAsync();
        }
    }
}
