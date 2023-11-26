using CruderSimple.Core.Requests;
using CruderSimple.DynamoDb.Requests;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{entity_name}};

public static class Delete{{entity_name}}Request
{
    public record Query([FromRoute] string id) : DeleteRequest.Query(id);

    [EndpointRequest(EndpointMethod.DELETE, "v1", "{{entity_name}}/{id}", true{% if has_authentication == "true" %}, new string[] { }{%endif%})]
    public class Handler
        (I{{entity_name}}Repository repository)
        : DeleteRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Output, I{{entity_name}}Repository>(repository)
    {
    }
}