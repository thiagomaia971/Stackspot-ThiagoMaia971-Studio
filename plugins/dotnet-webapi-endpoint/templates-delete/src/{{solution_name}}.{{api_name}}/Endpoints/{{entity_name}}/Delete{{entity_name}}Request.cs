using CruderSimple.Core.Requests;
using CruderSimple.Core.Requests.Base;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;

namespace {{solution_name}}.{{api_name}}.Endpoints.{{entity_name}};

public static class Delete{{entity_name}}Request
{
    public record Query([FromRoute] string id) : DeleteRequest.Query(id);

    [EndpointRequest(
        method: EndpointMethod.DELETE, 
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
        : DeleteRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Output, I{{entity_name}}Repository>(repository)
    {
    }
}