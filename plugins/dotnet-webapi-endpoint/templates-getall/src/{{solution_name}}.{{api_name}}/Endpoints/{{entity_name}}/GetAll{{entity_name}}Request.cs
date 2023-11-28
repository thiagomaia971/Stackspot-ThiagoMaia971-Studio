using CruderSimple.Core.Requests;
using CruderSimple.DynamoDb.Requests;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;

namespace {{solution_name}}.{{api_name}}.Endpoints.{{entity_name}};

public static class GetAll{{entity_name}}Request
{
    public record Query : GetAllRequest.Query;

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "{{entity_name}}", 
        {% if has_authentication == "True" %}
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
        {%else%}
        requireAuthorization: false)]
        {%endif%}
    public class Handler
        (I{{entity_name}}Repository repository)
        : GetAllRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Output, I{{entity_name}}Repository>(repository)
    {
    }
}