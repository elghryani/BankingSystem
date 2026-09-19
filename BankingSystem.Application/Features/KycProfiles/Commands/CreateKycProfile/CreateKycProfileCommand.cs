using BankingSystem.Domain.Enums;
using MediatR;
namespace BankingSystem.Application.Features.KycProfiles.Commands.CreateKycProfile
{
    public record CreateKycProfileCommand(Guid CustomerId,
        string IdentityNumber,
        DateOnly DateOfBirth,
        string Address,
        EnSourceOfIncome SourceOfIncome
        ) : IRequest<Guid>;
    
    
}
