using Test.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Test.Infrastructure.IdentityServices;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MediatR;
using System.Text;
using DynamoDbMapper.Sdk.Configurations;
using Test.Domain.Models;
using Test.Domain.Models.AutoMappers;
using Test.Domain.Interfaces.Repositories;
using Test.Infrastructure.Repositories;

namespace Test.Api;

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

        services
            .AddScoped<IUserStore<User>, UserStore>()
            .AddScoped<IRoleStore<Role>, RoleStore>()
            .AddIdentity<User, Role>()
            .AddDefaultTokenProviders();

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
        return services;
    }

    private static IServiceCollection AddInfrastructure(
        this IServiceCollection infraServices,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        infraServices.AddDynamodbMapper(configuration, environment);
        infraServices.AddRepositories(typeof(User));
        infraServices.AddScoped<IUserRepository, UserRepository>();
infraServices.AddScoped<IPatientRepository, PatientRepository>();
        return infraServices
            //.AddScoped<IUsuarioRepository, UsuarioRepository>()
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
}