namespace CustomerManagement.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(Guid customerId);
        Task DeleteAsync(Guid customerId);
        Task UpdateAsync(Customer customer);
    }
}
