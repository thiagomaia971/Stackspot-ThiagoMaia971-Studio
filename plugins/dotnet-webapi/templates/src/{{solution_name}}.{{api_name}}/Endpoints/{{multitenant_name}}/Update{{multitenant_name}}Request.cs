using CruderSimple.Core.Requests;
using CruderSimple.Core.Requests.Base;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

namespace {{solution_name}}.{{api_name}}.Endpoints.{{multitenant_name}};

public static class Update{{multitenant_name}}Request
{
    public record Query([FromRoute] string id, [FromBody] {{multitenant_name}}Input payload ) : UpdateRequest.Query<{{multitenant_name}}Input>(id, payload);
    
    [EndpointRequest(
        method: EndpointMethod.PUT, 
        version: "v1", 
        endpoint: "{{multitenant_name}}/{id}", 
        requireAuthorization: true, 
        new string[] { "ac337365-e690-4c75-9f05-e5ea75caa1e5" })]
    public class Handler
        (I{{multitenant_name}}Repository repository)
        : UpdateRequest.Handler<Query, Domain.Models.{{multitenant_name}}, {{multitenant_name}}Input, {{multitenant_name}}Output, I{{multitenant_name}}Repository>(repository)
    {
    }
}