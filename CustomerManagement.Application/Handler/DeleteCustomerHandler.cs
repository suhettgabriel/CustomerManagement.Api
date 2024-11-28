using CustomerManagement.Application.Commands;
using CustomerManagement.Domain.Interfaces;
using MediatR;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.CustomerId);
        return true;
    }
}
