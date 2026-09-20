using MediatR;
namespace BankingSystem.Application.Features.Customers.Commands.ActivateCustomer
{
    public record ActivateCustomerCommand(Guid customerId) : IRequest<ActivateCustomerResponse>;
    
    
}
