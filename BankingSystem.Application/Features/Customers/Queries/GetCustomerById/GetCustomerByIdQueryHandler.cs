using MediatR;
using BankingSystem.Domain.Entities;
using BankingSystem.Application.Interfaces;
using BankingSystem.Application.Exceptions;

namespace BankingSystem.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdWithProfileAsync(request.Id);

            if (customer == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }
            if(customer.Profile is null)
                throw new NotFoundException(nameof(customer.Profile), request.Id);

            return new GetCustomerByIdResponse(
                customer.Id,
                customer.FirstName + ' ' + customer.LastName,
                customer.PhoneNumber,
                customer.Status,
                customer.Profile?.IdentityNumber,
                customer.Profile?.Address,
                customer.Profile.DateOfBirth,
                customer.Profile.SourceOfIncome
                );
        }
    }
}