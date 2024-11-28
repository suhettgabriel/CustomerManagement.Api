using MediatR;
using System.Collections.Generic;

namespace CustomerManagement.Application.Commands
{
    public class GetCustomerQuery : IRequest<List<CustomerViewModel>> 
    {
    }
}
