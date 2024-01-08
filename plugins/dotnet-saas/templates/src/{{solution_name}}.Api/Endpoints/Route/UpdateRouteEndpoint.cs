using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Route;

public static class UpdateRouteEndpoint
{
    public record Query([FromRoute] string id, [FromBody] RouteDto payload ) : UpdateRequest.Query<RouteDto>(id, payload);
    
    [EndpointRequest(
        method: EndpointMethod.PUT, 
        version: "v1", 
        endpoint: "Route/{id}", 
        requireAuthorization: true, 
        new string[] { /* YOUR RouteS HERE */ })]
    public class Handler
        (IRepository<Domain.Models.Identity.Route> repository)
        : UpdateRequest.Handler<Query, Domain.Models.Identity.Route, RouteDto, IRepository<Domain.Models.Identity.Route>>(repository)
    {
    }
}