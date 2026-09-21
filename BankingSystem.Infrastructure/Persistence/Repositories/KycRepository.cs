using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Infrastructure.Persistence.Repositories
{
    public class KycRepository : Repository<KycProfile>, IKycRepository
    {
        public KycRepository(AppDbContext appDbContext) : base(appDbContext) { }
        public async Task<bool> IdentityNumberExistsAsync(string identityNumber, CancellationToken cancellationToken)
        {
            return await _appDbContext.KycProfiles.AnyAsync(x =>  x.IdentityNumber == identityNumber, cancellationToken);
        }
    }
}
