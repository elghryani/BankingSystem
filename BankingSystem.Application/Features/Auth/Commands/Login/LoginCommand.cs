using MediatR;
namespace BankingSystem.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(string userName, string password) : IRequest<LoginResponse>;
    
    
}
