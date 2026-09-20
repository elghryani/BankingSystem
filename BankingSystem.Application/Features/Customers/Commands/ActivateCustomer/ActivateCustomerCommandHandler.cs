using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using MediatR;
namespace BankingSystem.Application.Features.Customers.Commands.ActivateCustomer
{
    public class ActivateCustomerCommandHandler : IRequestHandler<ActivateCustomerCommand, ActivateCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActivateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActivateCustomerResponse> Handle(ActivateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer =await _unitOfWork.CustomerRepository.GetByIdWithKycAsync(request.customerId);

            if (customer == null) 
            {
                throw new NotFoundException<Customer>(request.customerId);
            }

            customer.Active();

            await _unitOfWork.SaveChangesAsync();

            return new ActivateCustomerResponse(customer.Id,
                customer.Status.ToString(),
                customer.Profile!.KYCStatus.ToString());

           
        }
    }
}
