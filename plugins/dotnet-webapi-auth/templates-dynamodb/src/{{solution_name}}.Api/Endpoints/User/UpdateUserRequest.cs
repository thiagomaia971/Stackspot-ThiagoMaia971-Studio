using CruderSimple.Core.Requests;
using CruderSimple.DynamoDb.Requests;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.UserViewModels;

namespace {{solution_name}}.Api.Endpoints.User;

public static class UpdateUserRequest
{
    public record Query([FromRoute] string id, [FromBody] UserInput payload ) : UpdateRequest.Query<UserInput>(id, payload);
    
    [EndpointRequest(
        method: EndpointMethod.PUT, 
        version: "v1", 
        endpoint: "User/{id}", 
        requireAuthorization: true, 
        new string[] { "ac337365-e690-4c75-9f05-e5ea75caa1e5" })]
    public class Handler
        (IUserRepository repository)
        : UpdateRequest.Handler<Query, Domain.Models.Identity.User, UserInput, UserOutput, IUserRepository>(repository)
    {
    }
}