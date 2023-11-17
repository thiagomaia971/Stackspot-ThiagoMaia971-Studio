using MediatR;
using System.Text;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Models.AutoMappers;
using {{solution_name}}.Domain.Interfaces.Repositories;

namespace {{solution_name}}.Api;

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
            .AddMediatR(typeof(Configurations))
            .AddRepositories(typeof(Entity));
            
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
        return infraServices
            //.AddScoped<IClinicaRepository, ClinicaRepository>()
            // .AddScoped<IAgendaRepository, AgendaRepository>()
            // .AddScoped<IRepository<Paciente>, Repository<Paciente>>()
            // .AddScoped<IRepository<Usuario>, UsuarioRepository>()
            // .AddScoped<IRepository<Role>, Repository<Role>>()
            // .AddScoped<IRepository<Material>, Repository<Material>>()
            // .AddScoped<IRepository<Atendimento>, Repository<Atendimento>>()
            // .AddScoped<IRepository<UserRole>, Repository<UserRole>>()
            //.AddScoped<IRepository<UserRole>, Repository<UserRole>>()
            ;
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        params Type[] entityScanMarkers)
    {
        foreach (Type entityScanMarker in entityScanMarkers)
        {
            foreach (Type type in entityScanMarker.Assembly.ExportedTypes.Where<Type>((Func<Type, bool>) (x => typeof (Entity).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)))
            {
                Type serviceType = typeof (IRepository<>).MakeGenericType(type);
                Type implementationType = typeof (Repository<>).MakeGenericType(type);
                services.AddScoped(serviceType, implementationType);
            }
        }
        return services;
    }
}