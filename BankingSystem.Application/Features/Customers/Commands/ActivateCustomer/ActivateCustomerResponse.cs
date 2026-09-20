namespace BankingSystem.Application.Features.Customers.Commands.ActivateCustomer
{
    public record ActivateCustomerResponse(Guid customerId,string status,string? kycStatus,string message = "Customer activated successfully.");
    
    
}
