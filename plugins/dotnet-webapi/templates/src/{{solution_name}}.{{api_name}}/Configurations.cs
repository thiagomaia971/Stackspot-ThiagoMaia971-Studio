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

        services
            .AddScoped<DbContext, {{solution_name}}DbContext>()
            .AddDbContext<{{solution_name}}DbContext>(
                x =>
                {
                    x.EnableSensitiveDataLogging(true);
                    var connectionString = configuration.GetConnectionString("DefaultConnection");
                    x.UseMySQL(connectionString);
                }, ServiceLifetime.Scoped, ServiceLifetime.Scoped);

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