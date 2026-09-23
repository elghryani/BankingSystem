using BankingSystem.Domain.Enums;

namespace BankingSystem.Application.Features.Auth.Commands.Login
{
    public record LoginResponse(string userName,string phoneNumber,EnUserStatus status,string accessToken);
    
    
}
