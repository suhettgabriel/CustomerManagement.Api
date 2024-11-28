using CustomerManagement.Domain.Enums;

namespace CustomerManagement.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public CompanySize CompanySize { get; set; }
    }
}
