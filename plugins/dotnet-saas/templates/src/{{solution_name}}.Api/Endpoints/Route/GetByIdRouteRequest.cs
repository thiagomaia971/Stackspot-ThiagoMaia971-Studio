using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Route;

public static class GetByIdRouteRequest
{
    public record Query([FromRoute] string id) : GetByIdRequest.Query(id);

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "Route/{id}", 
        requireAuthorization: true, 
        new string[] { /* YOUR RouteS HERE */ })]
    public class Handler
        (IRepository<Domain.Models.Identity.Route> repository)
        : GetByIdRequest.Handler<Query, Domain.Models.Identity.Route, RouteDto, IRepository<Domain.Models.Identity.Route>>(repository)
    {
    }
}