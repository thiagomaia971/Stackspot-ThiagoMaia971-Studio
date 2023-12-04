using CruderSimple.Core.Requests;
using CruderSimple.Core.Requests.Base;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

namespace {{solution_name}}.{{api_name}}.Endpoints.{{multitenant_name}};

public static class GetAll{{multitenant_name}}Request
{
    public record Query : GetAllRequest.Query;

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "{{multitenant_name}}", 
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (I{{multitenant_name}}Repository repository)
        : GetAllRequest.Handler<Query, Domain.Models.{{multitenant_name}}, {{multitenant_name}}Output, I{{multitenant_name}}Repository>(repository)
    {
    }
}