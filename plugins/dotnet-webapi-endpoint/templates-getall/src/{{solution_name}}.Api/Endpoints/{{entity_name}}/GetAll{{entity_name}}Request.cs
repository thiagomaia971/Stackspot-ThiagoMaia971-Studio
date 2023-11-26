using CruderSimple.Core.Requests;
using CruderSimple.DynamoDb.Requests;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;

namespace {{solution_name}}.Api.Endpoints.{{entity_name}};

public static class GetAll{{entity_name}}Request
{
    public record Query : GetAllRequest.Query;

    [EndpointRequest(EndpointMethod.GET, "v1", "{{entity_name}}", true{% if has_authentication == "true" %}, new string[] { }{%endif%})]
    public class Handler
        (I{{entity_name}}Repository repository)
        : GetAllRequest.Handler<Query, Domain.Models.{{entity_name}}, {{entity_name}}Output, I{{entity_name}}Repository>(repository)
    {
    }
}