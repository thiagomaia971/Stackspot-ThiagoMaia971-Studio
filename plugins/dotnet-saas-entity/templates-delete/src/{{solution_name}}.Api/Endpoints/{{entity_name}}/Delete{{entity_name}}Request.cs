using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{entity_name}};

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
        (IRepository<Domain.Models.{{entity_name}}> repository)
        : DeleteRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Dto, IRepository<Domain.Models.{{entity_name}}>>(repository)
    {
    }
}