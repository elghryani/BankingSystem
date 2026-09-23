using MediatR;
namespace BankingSystem.Application.Features.Auth.Queries.GetCurrentUser
{
    public record GetCurrentUserQuery() : IRequest<CurrentUserResponse>;
    
    
}
