using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.EndpointQueries.User;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.User;


public static class GetAllUserRequest
{
    public record Query(
        [FromQuery] string select = "*",
        [FromQuery] string filter = "",
        [FromQuery] string orderBy = "", 
        [FromQuery] int size = 10, 
        [FromQuery] int page = 1) : UserGetAllQuery(select, filter, orderBy, size, page);

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "User", 
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (IUserRepository repository)
        : GetAllRequest.Handler<Query, Domain.Models.Identity.User, UserDto, IUserRepository>(repository)
    {
    }
}