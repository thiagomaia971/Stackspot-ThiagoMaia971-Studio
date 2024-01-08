using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Route;

public static class CreateRouteEndpoint
{
    public record Query([FromBody] RouteDto payload) : CreateRequest.Query<RouteDto>(payload);

    [EndpointRequest(
        method: EndpointMethod.POST, 
        version: "v1", 
        endpoint: "Route", 
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (
            IRepository<Domain.Models.Identity.Route> repository
        )
        : CreateRequest.Handler<Query, Domain.Models.Identity.Route, RouteDto, IRepository<Domain.Models.Identity.Route>>(repository)
    {
    }
}