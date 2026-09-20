using FluentValidation;
namespace BankingSystem.Application.Features.Customers.Commands.ActivateCustomer
{
    public class ActivateCustomerCommandValidator : AbstractValidator<ActivateCustomerCommand>
    {
        public ActivateCustomerCommandValidator() 
        {
            RuleFor(x => x.customerId)
                .NotEmpty()
                .WithMessage("Customer ID is required.");
        }

    }
}
