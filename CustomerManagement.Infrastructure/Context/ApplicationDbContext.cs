using Microsoft.EntityFrameworkCore;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}