using CustomerManagement.Application.Commands;
using CustomerManagement.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace CustomerManagement.Application.Handler
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<CreateCustomerCommand> _validator;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IValidator<CreateCustomerCommand> validator)
        {
            _customerRepository = customerRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var customer = new Customer
            {
                CompanyName = request.CompanyName,
                CompanySize = request.CompanySize
            };

            await _customerRepository.AddAsync(customer);
            return true;
        }
    }
}
