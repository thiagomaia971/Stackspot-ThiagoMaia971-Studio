using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.User;

public static class DeleteUserRequest
{
    public record Query([FromRoute] string id) : DeleteRequest.Query(id);

    [EndpointRequest(
        method: EndpointMethod.DELETE, 
        version: "v1", 
        endpoint: "User/{id}", 
        requireAuthorization: true, 
        new string[] {  })]
    public class Handler
        (IUserRepository repository)
        : DeleteRequest.Handler<Query, Domain.Models.Identity.User, UserDto, IUserRepository>(repository)
    {
    }
}