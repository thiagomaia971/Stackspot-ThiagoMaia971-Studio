namespace {{solution_name}}.{{api_name}};

public static class Configurations
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddInfrastructure(configuration, environment);

        return services;
    }
    
    private static IServiceCollection AddInfrastructure(
        this IServiceCollection infraServices,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        return infraServices;
    }
}