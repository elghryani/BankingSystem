using MediatR;
namespace BankingSystem.Application.Features.Customers.Queries.GetPendingCustomers
{
public record GetPendingCustomersQuery : IRequest<List<GetPendingCustomersResponse>>;
}