using CruderSimple.Core.Requests;
using CruderSimple.DynamoDb.Requests;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.UserViewModels;

namespace {{solution_name}}.Api.Endpoints.User;

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