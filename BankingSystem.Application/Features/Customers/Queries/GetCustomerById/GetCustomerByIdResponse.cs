using BankingSystem.Domain.Enums;

namespace BankingSystem.Application.Features.Customers.Queries.GetCustomerById
{
        public record GetCustomerByIdResponse(
        Guid Id,
        string FullName,
        string PhoneNumber,
        EnUserStatus Status,
        string? IdentityNumber,
        string? Address,
        DateOnly DateOfBirth,
        EnSourceOfIncome SourceOfIncome

        );
    
}
