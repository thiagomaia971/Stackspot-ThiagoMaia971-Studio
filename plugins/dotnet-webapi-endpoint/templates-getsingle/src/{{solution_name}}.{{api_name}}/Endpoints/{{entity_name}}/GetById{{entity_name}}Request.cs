using CruderSimple.Core.Requests;
using CruderSimple.Core.Requests.Base;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{entity_name}};

namespace {{solution_name}}.{{api_name}}.Endpoints.{{entity_name}};

public static class GetById{{entity_name}}Request
{
    public record Query([FromRoute] string id) : GetByIdRequest.Query(id);

    [EndpointRequest(
        method: EndpointMethod.GET, 
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
        : GetByIdRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Output, I{{entity_name}}Repository>(repository)
    {
    }
}