using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{entity_name}};

public static class Create{{entity_name}}Request
{
    public record Query([FromBody] {{entity_name}}Dto payload) : CreateRequest.Query<{{entity_name}}Dto>(payload);

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
        (IRepository<Domain.Models.{{entity_name}}> repository)
        : CreateRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Dto, IRepository<Domain.Models.{{entity_name}}>>(repository)
    {
    }
}