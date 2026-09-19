using FluentValidation;
namespace BankingSystem.Application.Features.KycProfiles.Commands.CreateKycProfile
{
    public class CreateKycProfileCommandValidator : AbstractValidator<CreateKycProfileCommand>
    {
        public CreateKycProfileCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required.");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty()
                .WithMessage("Identity number is required.")
                .MaximumLength(15)
                .WithMessage("Identity number must not exceed 50 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required.")
                .MaximumLength(50)
                .WithMessage("Address must not exceed 200 characters.");

            RuleFor(x => x.SourceOfIncome)
                .IsInEnum()
                .WithMessage("Invalid source of income.");
        }
    }
}
