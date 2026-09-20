using FluentValidation;
namespace BankingSystem.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator() 
        {
            RuleFor(x => x.customerId)
                .NotEmpty()
                .WithMessage("Customer ID is required.");
        }
    }
}
