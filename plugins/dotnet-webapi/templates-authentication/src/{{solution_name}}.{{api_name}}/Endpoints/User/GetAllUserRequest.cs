using CruderSimple.Core.Requests;
using CruderSimple.Core.Requests.Base;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.{{api_name}}.Endpoints.User;

public static class GetAllUserRequest
{
    public record Query : GetAllRequest.Query;

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "User", 
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (IUserRepository repository)
        : GetAllRequest.Handler<Query, Domain.Models.Identity.User, UserOutput, IUserRepository>(repository)
    {
    }
}