using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces
{
    public interface IKycRepository : IRepository<KycProfile>
    {
        Task<bool> IdentityNumberExistsAsync(string identityNumber,CancellationToken cancellationToken);
    }
}
