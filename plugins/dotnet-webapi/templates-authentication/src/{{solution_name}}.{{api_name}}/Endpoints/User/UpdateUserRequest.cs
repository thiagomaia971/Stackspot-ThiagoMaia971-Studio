using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.{{api_name}}.Endpoints.User;

public static class UpdateUserRequest
{
    public record Query([FromRoute] string id, [FromBody] UserDto payload ) : UpdateRequest.Query<UserDto>(id, payload);
    
    [EndpointRequest(
        method: EndpointMethod.PUT, 
        version: "v1", 
        endpoint: "User/{id}", 
        requireAuthorization: true, 
        new string[] { "ac337365-e690-4c75-9f05-e5ea75caa1e5" })]
    public class Handler
        (IUserRepository repository)
        : UpdateRequest.Handler<Query, Domain.Models.Identity.User, UserDto, UserOutput, IUserRepository>(repository)
    {
    }
}