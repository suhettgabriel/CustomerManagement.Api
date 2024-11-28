using CustomerManagement.Application.Commands;
using CustomerManagement.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
            // Aqui você pode adicionar lógica para mapear os dados do repositório para um modelo de consulta, por exemplo
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerViewModel
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                CompanySize = c.CompanySize
            }).ToList();
        }
    }
}
