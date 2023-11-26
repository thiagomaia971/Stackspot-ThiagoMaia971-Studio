using CruderSimple.Core.Requests;
using CruderSimple.DynamoDb.Requests;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{entity_name}};

public static class Create{{entity_name}}Request
{
    public record Query([FromBody] {{entity_name}}Input payload) : CreateRequest.Query<{{entity_name}}Input>(payload);

    [EndpointRequest(EndpointMethod.POST, "v1", "{{entity_name}}", true{% if has_authentication == "true" %}, new string[] { }{%endif%})]
    public class Handler
        (I{{entity_name}}Repository repository)
        : CreateRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Input, {{entity_name}}Output, I{{entity_name}}Repository>(repository)
    {
    }
}