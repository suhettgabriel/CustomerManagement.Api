using CustomerManagement.Domain.Enums;

namespace CustomerManagement.Application.Commands
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public CompanySize CompanySize { get; set; }
    }
}
