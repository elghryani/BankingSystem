namespace BankingSystem.Application.Features.Auth.Queries.GetCurrentUser
{
    public record CurrentUserResponse(
    Guid Id,
    string UserName,
    string PhoneNumber,
    string Status);
}
