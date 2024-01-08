using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using CruderSimple.Core.EndpointQueries;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{entity_name}};

public static class GetAll{{entity_name}}Endpoint
{
    public record Query(
        [FromQuery] string select = "Id",
        [FromQuery] string filter = "",
        [FromQuery] string orderBy = "",
        [FromQuery] int size = 10,
        [FromQuery] int page = 1) : GetAllEndpointQuery(select, filter, orderBy, size, page);

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
        (IRepository<Domain.Models.{{entity_name}}> repository)
        : GetAllRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Dto, IRepository<Domain.Models.{{entity_name}}>>(repository)
    {
    }
}