using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using MediatR;
namespace BankingSystem.Application.Features.KycProfiles.Commands.CreateKycProfile
{
    public class CreateKycProfileCommandHandler : IRequestHandler<CreateKycProfileCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateKycProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateKycProfileCommand request, CancellationToken cancellationToken)
        {
            var customer =await _unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
            {
                throw new NotFoundException(nameof(Customer),request.CustomerId);
            }

            if (await _unitOfWork.KycRepository.IdentityNumberExistsAsync(request.IdentityNumber,cancellationToken)) 
            {
                throw new IdentityNumberAlreadyExistsException();
            }

            customer.AddKycProfile(request.IdentityNumber, request.DateOfBirth, request.Address, request.SourceOfIncome);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return customer.Profile!.Id;
        }
    }
}
