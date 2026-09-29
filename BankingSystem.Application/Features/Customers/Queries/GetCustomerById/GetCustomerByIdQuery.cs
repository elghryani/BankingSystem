using MediatR;
namespace BankingSystem.Application.Features.Customers.Queries.GetCustomerById
{
public record GetCustomerByIdQuery(Guid Id) : IRequest<GetCustomerByIdResponse>;
}