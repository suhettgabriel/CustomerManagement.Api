using CustomerManagement.Domain.Enums;
using MediatR;

namespace CustomerManagement.Application.Commands
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public Guid CustomerId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public CompanySize CompanySize { get; set; }
    }
}
