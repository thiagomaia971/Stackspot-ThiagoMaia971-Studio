using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.Core.EndpointQueries;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.EndpointQueries.{{multitenant_name}};
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{multitenant_name}};

public static class GetAll{{multitenant_name}}Endpoint
{
    public record Query(
        [FromQuery] string select = "*", 
        [FromQuery] string filter = "", 
        [FromQuery] string orderBy = "", 
        [FromQuery] int size = 10, 
        [FromQuery] int page = 1) : {{multitenant_name}}GetAllQuery(select, filter, orderBy, size, page);

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "{{multitenant_name}}", 
        requireAuthorization: true,
    new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (I{{multitenant_name}}Repository repository)
        : GetAllRequest.Handler<Query, Domain.Models.{{multitenant_name}}, {{multitenant_name}}Dto, I{{multitenant_name}}Repository>(repository)
    {
    }
}