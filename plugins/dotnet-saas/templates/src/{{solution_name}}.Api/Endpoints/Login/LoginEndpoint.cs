using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CruderSimple.Api.Requests.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using {{solution_name}}.Domain.Interfaces.Repositories;
using CruderSimple.Core.ViewModels;
using CruderSimple.Core.ViewModels.Login;
using CruderSimple.Core.EndpointQueries;

namespace {{solution_name}}.Api.Endpoints.Login;

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
         UserManager<Domain.Models.Identity.User> userManager,
         IRouteRepository routeRepository)
        : HttpHandlerBase<Query, Domain.Models.Identity.User, Result>, IRequestHandler<Query, Result>
    {
        public override async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(request.payload.Email);
                if (user is null)
                    throw new Exception("User not found");

                if (await userManager.CheckPasswordAsync(user, request.payload.Password))
                {
                    var userRoles = await userManager.GetRolesAsync(user);
                    var routes = await routeRepository.GetAll();
                    var permissions = user.GetPermissions();

                    var authClaims = new List<Claim>
                {
                    new Claim("UserId", user.Id),
                    new Claim("TenantId", user.{{multitenant_name}}Id),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("Permissions", string.Join(",", permissions)),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                    authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));
                    var token = GetToken(configuration, authClaims);
                    var loginResult = new LoginResult
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        UserId = user.Id,
                        UserName = user.Name/*,
                        User = new LoginUserResult
                        {
                            Id = user.Id,
                            ClinicId = user.ClinicId,
                            Email = user.Email,
                            Name = user.Name,
                            Roles = user.Roles.Select(x => x.Id),
                            Permissions = user.GetPermissions()
                        },
                        Routes = routes.Data.OrderBy(x => x.Name).Select(x => new LoginRouteResult
                        {
                            Name = x.Name,
                            Parent = x.Parent,
                            Url = x.Url,
                            Icon = x.Icon,
                            Position = x.Position,
                            Visible = x.Visible
                        })*/
                    };
                    return Result.CreateSuccess(loginResult);
                }

                return Result.CreateError("Não autorizado", 401, "Não autorizado");
            }
            catch (Exception e)
            {
                return Result.CreateError(e.StackTrace, 500, e.Message);
                throw;
            }
        }

        private static JwtSecurityToken GetToken(IConfiguration configuration, List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddYears(900),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}