using CustomerManagement.Domain.Entities;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid customerId);
    }
}
