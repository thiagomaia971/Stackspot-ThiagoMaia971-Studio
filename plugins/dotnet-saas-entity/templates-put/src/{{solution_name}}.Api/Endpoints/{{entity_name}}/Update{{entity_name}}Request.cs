using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{entity_name}};

public static class Update{{entity_name}}Request
{
    public record Query([FromRoute] string id, [FromBody] {{entity_name}}Dto payload ) : UpdateRequest.Query<{{entity_name}}Dto>(id, payload);
    
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
        (IRepository<Domain.Models.{{entity_name}}> repository)
        : UpdateRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Dto, IRepository<Domain.Models.{{entity_name}}>>(repository)
    {
    }
}