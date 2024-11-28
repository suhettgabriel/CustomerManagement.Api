using CustomerManagement.Infrastructure.Context;
using CustomerManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Application.Commands;
using CustomerManagement.Domain.Interfaces;

namespace CustomerManagement.Api.Configurations
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>());
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
