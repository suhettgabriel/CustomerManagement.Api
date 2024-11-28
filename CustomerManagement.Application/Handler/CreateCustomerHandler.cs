using CustomerManagement.Application.Commands;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
            // Validar o comando
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Criar entidade de cliente
            var customer = new Customer
            {
                CompanyName = request.CompanyName,
                CompanySize = request.CompanySize
            };

            // Salvar no repositório
            await _customerRepository.AddAsync(customer);
            return true;
        }
    }
}
