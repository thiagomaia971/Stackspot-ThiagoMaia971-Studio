using CruderSimple.Core.Requests;
using CruderSimple.DynamoDb.Requests;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.UserViewModels;

namespace {{solution_name}}.{{api_name}}.Endpoints.User;

public static class GetByIdUserRequest
{
    public record Query([FromRoute] string id) : GetByIdRequest.Query(id);

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "User/{id}", 
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (IUserRepository repository)
        : GetByIdRequest.Handler<Query, Domain.Models.Identity.User, UserOutput, IUserRepository>(repository)
    {
    }
}