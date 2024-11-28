using CustomerManagement.Application.Commands;
using CustomerManagement.Domain.Interfaces;
using MediatR;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Id = request.CustomerId, 
            CompanyName = request.CompanyName,
            CompanySize = request.CompanySize
        };

        await _repository.UpdateAsync(customer);
        return true;
    }
}
