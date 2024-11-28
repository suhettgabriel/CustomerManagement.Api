using MediatR;

namespace CustomerManagement.Application.Commands
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public Guid CustomerId { get; set; }
    }
}
