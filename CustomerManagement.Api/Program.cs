using FluentValidation.AspNetCore;
using CustomerManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Api.Configurations;
using CustomerManagement.Application.Commands;
using MediatR;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Registrar servi�os no cont�iner de DI
        builder.Services.AddControllers();

        // Adicionar suporte ao Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Registrar validadores do FluentValidation
        builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerCommand>());

        // Registrar MediatR
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>());

        // Adicionar depend�ncias de aplica��o e infraestrutura
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);

        // Configura��o do banco de dados (DbContext)
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Configura��o de CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        var app = builder.Build();

        // Configura��o do Swagger
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerConfiguration();
        }

        // Aplicar CORS
        app.UseCors("AllowAll");

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
