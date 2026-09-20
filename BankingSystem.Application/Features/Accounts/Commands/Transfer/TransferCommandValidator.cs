using FluentValidation;
namespace BankingSystem.Application.Features.Accounts.Commands.Transfer
{
    public class TransferCommandValidator : AbstractValidator<TransferCommand>
    {
        public TransferCommandValidator() 
        {
            RuleFor(x => x.fromAccountNumber)
                .NotEmpty()
                .WithMessage("From account number is required.");
            
            RuleFor(x => x.toAccountNumber)
                .NotEmpty().
                WithMessage("To account number is required.");
            
            RuleFor(x => x.amount)
                .GreaterThan(0)
                .WithMessage("Transfer amount must be greater than zero.");
            
        }
    }
}
