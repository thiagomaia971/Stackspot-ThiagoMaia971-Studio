using System.Security.Claims;
using DynamoDbMapper.Sdk.Entities;

namespace {{solution_name}}.Api.Filters
{
    public class MultiTenantActionFilter : IEndpointFilter
    {
        private readonly MultiTenantScoped multiTenant;

        public MultiTenantActionFilter(MultiTenantScoped multiTenant)
        {
            this.multiTenant = multiTenant;
        }

        public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var claims = context.HttpContext.User.Identity as ClaimsIdentity;
            if (claims.Claims.Any(x => x.Type == "UserId"))
            {
                var userId = claims.Claims.First(x => x.Type == "UserId").Value;
                multiTenant.UserId = userId;
            }
            return next(context);
        }
    }
}
