using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.Core.EndpointQueries;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Route;


public static class GetAllRouteRequest
{
    public record Query(
        [FromQuery] string select = "*",
        [FromQuery] string filter = "",
        [FromQuery] string orderBy = "", 
        [FromQuery] int size = 10, 
        [FromQuery] int page = 1) : GetAllEndpointQuery(select, filter, orderBy, size, page);

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "Route", 
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (IRepository<Domain.Models.Identity.Route> repository)
        : GetAllRequest.Handler<Query, Domain.Models.Identity.Route, RouteDto, IRepository<Domain.Models.Identity.Route>>(repository)
    {
    }
}