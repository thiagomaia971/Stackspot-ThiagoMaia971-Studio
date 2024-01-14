using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.User;

public static class GetByIdUserEndpoint
{
    public record Query([FromRoute] string id, [FromQuery] string select = "*") : GetByIdRequest.Query(id, select);

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "User/{id}", 
        requireAuthorization: true, 
        new string[] { /* YOUR UserS HERE */ })]
    public class Handler
        (IUserRepository repository)
        : GetByIdRequest.Handler<Query, Domain.Models.Identity.User, UserDto, IUserRepository>(repository)
    {
    }
}