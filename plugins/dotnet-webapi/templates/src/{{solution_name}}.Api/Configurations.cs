using MediatR;
using System.Text;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Models.AutoMappers;
using {{solution_name}}.Infrastructure.Repositories.Base;
using {{solution_name}}.Domain.Interfaces.Repositories.Base;


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
            .AddRepositories(typeof(Entity))
            //.AddScoped<IUserStore<Usuario>, UserStore>()
            //.AddScoped<IRoleStore<Role>, RoleStore>()
            //.AddIdentity<Usuario, Role>()
            //.AddDefaultTokenProviders()
            ;
         /*   
        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = configuration["Jwt:ValidIssuer"],
                ValidAudience = configuration["Jwt:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                
            };
        });
       services.AddAuthorization(options =>
       {
           foreach (var role in Roles.ALL)
           {
               options.AddPolicy(role, builder => builder.RequireRole(role));
               //options.AddPolicy($"{role}:{Policy.READ}", builder => builder.RequireRole(role));
               //options.AddPolicy($"{role}:{Policy.WRITE}", builder => builder.RequireRole(role));
               //options.AddPolicy($"{role}:{Policy.ALL}", builder => builder.RequireRole(role));
           }
       });
        
        */
        services.AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddInfrastructure(configuration, environment);

        return services;
    }
    
    private static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        return services
            //.AddDynamodbMapper(configuration, environment)
            // .AddRepositories(typeof(Usuario))
            //.AddScoped<IUsuarioRepository, UsuarioRepository>()
            //.AddScoped<IClinicaRepository, ClinicaRepository>()
            // .AddScoped<IAgendaRepository, AgendaRepository>()
            // .AddScoped<IRepository<Paciente>, Repository<Paciente>>()
            // .AddScoped<IRepository<Usuario>, UsuarioRepository>()
            // .AddScoped<IRepository<Role>, Repository<Role>>()
            // .AddScoped<IRepository<Material>, Repository<Material>>()
            // .AddScoped<IRepository<Atendimento>, Repository<Atendimento>>()
            // .AddScoped<IRepository<UsuarioRole>, Repository<UsuarioRole>>()
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