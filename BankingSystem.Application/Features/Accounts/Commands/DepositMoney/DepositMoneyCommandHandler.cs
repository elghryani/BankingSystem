using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using MediatR;
namespace BankingSystem.Application.Features.Accounts.Commands.DepositMoney
{
    public class DepositMoneyCommandHandler : IRequestHandler<DepositMoneyCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepositMoneyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DepositMoneyCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.AccountRepository.GetByAccountNumberAsync(request.accountNumber);

            if (account == null) 
            {
                throw new NotFoundException(nameof(Account),request.accountNumber);
            }
            account.Deposit(request.amount);

            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
