using MediatR;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Models.AutoMappers;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Infrastructure.Repositories;

namespace {{solution_name}}.{{api_name}};

public static class Configurations
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services
            .AddAutoMapper(typeof(AutoMapperProfile))
            .AddMediatR(typeof(Configurations));
            
        services.AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddInfrastructure(configuration, environment);

        return services;
    }
    
    private static IServiceCollection AddInfrastructure(
        this IServiceCollection infraServices,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        
        infraServices.AddDbContext<CustomDbContext>(
            x =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        );

        return infraServices;
    }
}