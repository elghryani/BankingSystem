using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using MediatR;
namespace BankingSystem.Application.Features.Accounts.Queries.GetSourceAccount
{
    public class GetSourceAccountQueryHandler : IRequestHandler<GetSourceAccountQuery, GetSourceAccountResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetSourceAccountQueryHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetSourceAccountResponse> Handle(GetSourceAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.AccountRepository.GetSourceAccountAsync(request.accountNumber);

            if (account is null)
                throw new NotFoundException(nameof(Account),request.accountNumber);

            

            return account;



        }
    }
}
