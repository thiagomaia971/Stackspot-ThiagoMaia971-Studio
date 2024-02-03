using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Role;

public static class DeleteRoleEndpoint
{
    public record Query([FromRoute] string id) : DeleteRequest.Query(id);

    [EndpointRequest(
        method: EndpointMethod.DELETE, 
        version: "v1", 
        endpoint: "Role/{id}", 
        requireAuthorization: true, 
        new string[] {  })]
    public class Handler
        (IRoleRepository repository)
        : DeleteRequest.Handler<Query, Domain.Models.Identity.Role, RoleDto, IRoleRepository>(repository)
    {
    }
}