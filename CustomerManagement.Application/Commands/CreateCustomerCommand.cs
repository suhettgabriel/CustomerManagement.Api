using CustomerManagement.Domain.Enums;
using MediatR;

namespace CustomerManagement.Application.Commands
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public string CompanyName { get; set; }
        public CompanySize CompanySize { get; set; }

        public CreateCustomerCommand(string companyName, CompanySize companySize)
        {
            CompanyName = companyName;
            CompanySize = companySize;
        }
    }
}
