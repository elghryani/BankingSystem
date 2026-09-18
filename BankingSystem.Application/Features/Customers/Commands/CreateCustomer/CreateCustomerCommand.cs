using BankingSystem.Domain.Enums;
using MediatR;

namespace BankingSystem.Application.Features.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(string FirstName,
        string LastName,
        string? Email,
        string PhoneNumber
        ) : IRequest<Guid>;
    
    
}
