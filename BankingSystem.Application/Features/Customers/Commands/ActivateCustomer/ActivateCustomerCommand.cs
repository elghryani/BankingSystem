using MediatR;
namespace BankingSystem.Application.Features.Customers.Commands.ActivateCustomer
{
    public record ActivateCustomerCommand(Guid CustomerId) : IRequest<ActivateCustomerResponse>;
    
    
}
