using BankingSystem.Domain.Enums;

namespace BankingSystem.Application.Features.Customers.Queries.GetPendingCustomers
{
    public record GetPendingCustomersResponse(
        Guid Id,
        string FullName,
        string PhoneNumber,
        EnUserStatus Status
    );
}