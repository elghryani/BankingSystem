using FluentValidation;
namespace BankingSystem.Application.Features.Accounts.Commands.DepositMoney
{
    public class DepositMoneyCommandValidator : AbstractValidator<DepositMoneyCommand>
    {
        public DepositMoneyCommandValidator() 
        {

            RuleFor(x => x.accountNumber)
                .NotEmpty()
                .WithMessage("account number is required.");

            

            RuleFor(x => x.amount)
                .GreaterThan(0)
                .WithMessage("Transfer amount must be greater than zero.");
        }
    }
}
