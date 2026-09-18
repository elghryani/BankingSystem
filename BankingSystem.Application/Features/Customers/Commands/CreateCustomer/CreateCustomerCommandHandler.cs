using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using MediatR;
namespace BankingSystem.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CustomerRepository.ExistsByPhoneNumberAsync(request.PhoneNumber))
            {
                throw new CustomerPhoneAlreadyExistsException(request.PhoneNumber);
            }

            var newCustomer = Customer.Create(request.FirstName, request.LastName,request.Email,request.PhoneNumber);
            await _unitOfWork.CustomerRepository.AddAsync(newCustomer);
            await _unitOfWork.SaveChangesAsync();

            return newCustomer.Id;
            
        }
    }
}
