using CruderSimple.Core.Requests;
using CruderSimple.Core.Requests.Base;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{entity_name}};

namespace {{solution_name}}.{{api_name}}.Endpoints.{{entity_name}};

public static class Create{{entity_name}}Request
{
    public record Query([FromBody] {{entity_name}}Input payload) : CreateRequest.Query<{{entity_name}}Input>(payload);

    [EndpointRequest(
        method: EndpointMethod.POST, 
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
        : CreateRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Input, {{entity_name}}Output, I{{entity_name}}Repository>(repository)
    {
    }
}