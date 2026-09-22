using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using MediatR;
namespace BankingSystem.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
       public CreateAccountCommandHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdWithKycAsync(request.customerId);

            if (customer == null) 
            {
                throw new NotFoundException(nameof(Account),request.customerId);
            }

            if (customer.Profile == null) 
            {
                throw new NotFoundException(nameof(KycProfile),request.customerId);
            }

            if(customer.Status == Domain.Enums.EnUserStatus.Active && customer.Profile.KYCStatus == Domain.Enums.EnKYCStatus.Verified)
            {
                string accuontNumber;

                do
                {
                    accuontNumber = Random.Shared.Next(10_000_000, 100_000_000).ToString();


                }while(await _unitOfWork.AccountRepository.ExistsByAccountNumberAsync(accuontNumber));
                
                var newAccuont = Account.Create(request.customerId, accuontNumber);

                await _unitOfWork.AccountRepository.AddAsync(newAccuont);
                await _unitOfWork.SaveChangesAsync();

                return new CreateAccountResponse(newAccuont.Id,
                    newAccuont.AccountNumber,
                    newAccuont.Balance,
                    newAccuont.Status.ToString(),
                    newAccuont.CreatedAt);

            }
            else
            {
                throw new CustomerNotActivatedException();
            }

        }
    }


}
