using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CruderSimple.Core.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.{{api_name}}.Endpoints.Login;

public static class LoginEndpoint
{
    public record Query([FromBody] LoginViewModel payload) : IEndpointQuery;
    
    [EndpointRequest(
        method: EndpointMethod.POST, 
        version: "v1", 
        endpoint: "login", 
        requireAuthorization: false)]
    public class Handler
        (IConfiguration configuration,
         UserManager<Domain.Models.Identity.User> userManager)
        : HttpHandlerBase<Query, Domain.Models.Identity.User>, IRequestHandler<Query, IResult>
    {
        public override async Task<IResult> Handle(Query request, CancellationToken cancellationToken)
        {
            
            var user = await userManager.FindByEmailAsync(request.payload.Email);
            if (user is null)
                throw new Exception("User not found");

            if (await userManager.CheckPasswordAsync(user, request.payload.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
            
                var authClaims = new List<Claim>
                {
                    new Claim("UserId", user.Id),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));
                var token = GetToken(configuration, authClaims);
                return Results.Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Results.Unauthorized();
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
}