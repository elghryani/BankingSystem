namespace BankingSystem.Application.Interfaces.Common
{
    public interface ITokenService
    {
        string GenerateToken(Guid employeeId, string userName);
    }
}
