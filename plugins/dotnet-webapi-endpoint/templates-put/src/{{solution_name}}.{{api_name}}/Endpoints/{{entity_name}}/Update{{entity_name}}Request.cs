using CruderSimple.Core.Requests;
using CruderSimple.DynamoDb.Requests;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;

namespace {{solution_name}}.{{api_name}}.Endpoints.{{entity_name}};

public static class Update{{entity_name}}Request
{
    public record Query([FromRoute] string id, [FromBody] {{entity_name}}Input payload ) : UpdateRequest.Query<{{entity_name}}Input>(id, payload);
    
    [EndpointRequest(
        method: EndpointMethod.PUT, 
        version: "v1", 
        endpoint: "{{entity_name}}/{id}", 
        {% if has_authentication == "True" %}
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
        {%else%}
        requireAuthorization: false)]
        {%endif%}
    public class Handler
        (I{{entity_name}}Repository repository)
        : UpdateRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Input, {{entity_name}}Output, I{{entity_name}}Repository>(repository)
    {
    }
}