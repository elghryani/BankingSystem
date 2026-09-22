using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using MediatR;
namespace BankingSystem.Application.Features.Accounts.Queries.GetDestinationAccount
{
    public class GetDestinationAccountQueryHandler : IRequestHandler<GetDestinationAccountQuery, GetDestinationAccountResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDestinationAccountQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetDestinationAccountResponse> Handle(GetDestinationAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.AccountRepository.GetDestinationAccount(request.accountNumber);

            if (account == null)
                throw new NotFoundException(nameof(Account),request.accountNumber);

            return account;
        }
    }
}
