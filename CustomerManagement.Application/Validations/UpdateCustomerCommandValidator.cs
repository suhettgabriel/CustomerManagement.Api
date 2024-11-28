using FluentValidation;
using CustomerManagement.Application.Commands;

namespace CustomerManagement.Application.Validations
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required.");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name is required.");
            RuleFor(x => x.CompanySize).IsInEnum().WithMessage("Invalid company size.");
        }
    }
}
