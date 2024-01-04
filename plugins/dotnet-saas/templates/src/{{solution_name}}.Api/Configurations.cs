using CruderSimple.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using {{solution_name}}.Infrastructure.Repositories;

namespace {{solution_name}}.Api;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using {{solution_name}}.Infrastructure.IdentityServices;
using {{solution_name}}.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using {{solution_name}}.Domain.Models.Identity;
        
using Microsoft.EntityFrameworkCore;

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
        return infraServices;
    }
}