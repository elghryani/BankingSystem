using BankingSystem.Application.Interfaces;
using BankingSystem.Application.Interfaces.Common;
using BankingSystem.Infrastructure.Persistence;
using BankingSystem.Infrastructure.Persistence.Repositories;
using BankingSystem.Infrastructure.Security;
using BankingSystem.Infrastructure.Security.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BankingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            services.AddHttpContextAccessor();

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddScoped<IKycRepository, KycRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            

            return services;
        }
    }
}
