using FluentValidation;
using CustomerManagement.Application.Commands;

namespace CustomerManagement.Application.Validations
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required.");
        }
    }
}
