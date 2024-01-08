using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{multitenant_name}};

public static class GetById{{multitenant_name}}Endpoint
{
    public record Query([FromRoute] string id) : GetByIdRequest.Query(id);

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "{{multitenant_name}}/{id}", 
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (I{{multitenant_name}}Repository repository)
        : GetByIdRequest.Handler<Query, Domain.Models.{{multitenant_name}}, {{multitenant_name}}Dto, I{{multitenant_name}}Repository>(repository)
    {
    }
}