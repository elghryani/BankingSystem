using FluentValidation;
namespace BankingSystem.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator 
        : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.FirstName)
              .NotEmpty()
              .WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^(091|092|093|094)\d{7}$")
                .WithMessage("Phone number must be 10 digits and start with 091, 092, 093, or 094.");
        }

    }
}
