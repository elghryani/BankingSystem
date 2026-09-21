using BankingSystem.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
           await _appDbContext.AddAsync(entity, cancellationToken);
        }

        public void Delete(T entity)
        {
            _appDbContext.Remove(entity);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<T>().AnyAsync(x => EF.Property<Guid>(x, "Id") == id, cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<T>().FindAsync([id], cancellationToken);
        }

        public void Update(T entity)
        {
            _appDbContext.Update(entity);
        }
    }
}
