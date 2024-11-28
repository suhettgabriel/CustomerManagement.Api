using CustomerManagement.Application.Commands;
using FluentValidation;

namespace CustomerManagement.Application.Validations
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name is required.");
            RuleFor(x => x.CompanySize).IsInEnum().WithMessage("Invalid company size.");
        }
    }
}
