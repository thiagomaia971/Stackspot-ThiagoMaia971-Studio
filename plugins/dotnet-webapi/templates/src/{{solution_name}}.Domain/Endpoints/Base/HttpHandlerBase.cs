using DynamoDbMapper.Sdk.Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Endpoints.Base;

public abstract class HttpHandlerBase<TQuery, TEntity> : IHttpRequestHandler
    where TQuery : IHttpRequest
    where TEntity : Entity
{
    public WebApplication AddEndpointDefinition(WebApplication app)
    {
        var httpRequestAttribute = (HttpRequest?)
            GetType().GetCustomAttributes(true).FirstOrDefault(x =>
                typeof(HttpRequest).IsAssignableFrom(x.GetType()));

        app.MapMethods(
            $"{httpRequestAttribute.Version}/{httpRequestAttribute.Endpoint}",
            new string[] { httpRequestAttribute.HttpMethod.ToString() },
            async ([FromServices] IMediator mediator, [AsParameters] TQuery query)
                => await mediator.Send(query))
            .WithTags(typeof(TEntity).Name);

        if (httpRequestAttribute.AuthorizeRole is not null && httpRequestAttribute.AuthorizeRole?.Length > 0)
            routeBuilder = routeBuilder.RequireAuthorization(httpRequestAttribute.AuthorizeRole);
        if (httpRequestAttribute.IsMultiTenant.HasValue && httpRequestAttribute.IsMultiTenant.Value)
            routeBuilder = routeBuilder.AddEndpointFilter<MultiTenantActionFilter>();
        
        return app;
    }

    public abstract Task<IResult> Handle(TQuery request, CancellationToken cancellationToken);
}