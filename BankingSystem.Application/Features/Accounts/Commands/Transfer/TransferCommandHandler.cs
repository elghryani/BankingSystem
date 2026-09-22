using BankingSystem.Application.Exceptions;
using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using MediatR;
namespace BankingSystem.Application.Features.Accounts.Commands.Transfer
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            var fromAccount = await _unitOfWork.AccountRepository.GetByAccountNumberAsync(request.fromAccountNumber);

            if (fromAccount == null)
                throw new NotFoundException(nameof(Account),request.fromAccountNumber);

            

            var toAccount = await _unitOfWork.AccountRepository.GetByAccountNumberAsync(request.toAccountNumber);

            if (toAccount == null)
                throw new NotFoundException(nameof(Account),request.toAccountNumber);

            fromAccount.Withdraw(request.amount);

            toAccount.Deposit(request.amount);

            return  await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;



        }
    }
}
