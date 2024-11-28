using CustomerManagement.Application.Commands;
using CustomerManagement.Domain.Interfaces;
using MediatR;

namespace CustomerManagement.Application.Handler
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<CustomerViewModel>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerViewModel>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerViewModel
            {
                Id = BitConverter.ToInt32(c.Id.ToByteArray(), 0),
                CompanyName = c.CompanyName,
                CompanySize = c.CompanySize
            }).ToList();
        }
    }
 }
