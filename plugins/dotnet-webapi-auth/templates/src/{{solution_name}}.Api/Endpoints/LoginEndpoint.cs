using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using {{solution_name}}.Api.Endpoints.Base;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Domain.ViewModels;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace {{solution_name}}.Api.Endpoints;

public class LoginEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/v1/login", PostLogin);
    }

    public void DefineHandlers(IServiceCollection services)
    {
    }

    private static async Task<Object> PostLogin(
        [FromBody] LoginViewModel login,
        [FromServices] IConfiguration configuration,
        [FromServices] UserManager<User> userManager/*,
        [FromServices] SignInManager<Usuario> _signInManager*/)
    {
        var user = await userManager.FindByEmailAsync(login.Email);
        if (user is null)
            throw new Exception("User not found");

        if (await userManager.CheckPasswordAsync(user, login.Password))
        {
                var userRoles = await userManager.GetRolesAsync(user);
            
            var authClaims = new List<Claim>
            {
                new Claim("UserId", user.Id),
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));
            var token = GetToken(configuration, authClaims);
            return (new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        throw new UnauthorizedAccessException();
    }

    private static JwtSecurityToken GetToken(IConfiguration configuration, List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddSeconds(900),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}

