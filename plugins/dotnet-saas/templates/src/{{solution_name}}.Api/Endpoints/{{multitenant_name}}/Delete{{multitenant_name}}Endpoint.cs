using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{multitenant_name}};

public static class Delete{{multitenant_name}}Endpoint
{
    public record Query([FromRoute] string id) : DeleteRequest.Query(id);

    [EndpointRequest(
        method: EndpointMethod.DELETE, 
        version: "v1", 
        endpoint: "{{multitenant_name}}/{id}", 
        requireAuthorization: true, 
        new string[] { "ac337365-e690-4c75-9f05-e5ea75caa1e5" })]
    public class Handler
        (I{{multitenant_name}}Repository repository)
        : DeleteRequest.Handler<Query, Domain.Models.{{multitenant_name}}, {{multitenant_name}}Dto, I{{multitenant_name}}Repository>(repository)
    {
    }
}