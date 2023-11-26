using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using {{solution_name}}.Infrastructure.IdentityServices;
using Microsoft.AspNetCore.Identity;
using {{solution_name}}.Domain.Models.Identity;
        
        services
{{"            .AddScoped<IUserStore<User>, UserStore>()
            .AddScoped<IRoleStore<Role>, RoleStore>()
            .AddIdentity<User, Role>()
            .AddDefaultTokenProviders();
        services"}}

