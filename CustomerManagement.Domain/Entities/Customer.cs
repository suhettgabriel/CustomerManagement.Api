using CustomerManagement.Domain.Enums;

public class Customer
{
    public Guid Id { get; set; } 
    public string? CompanyName { get; set; }
    public CompanySize CompanySize { get; set; }
}
