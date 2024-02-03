using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Role;

public static class UpdateRoleEndpoint
{
    public record Query([FromRoute] string id, [FromBody] RoleDto payload ) : UpdateRequest.Query<RoleDto>(id, payload);
    
    [EndpointRequest(
        method: EndpointMethod.PUT, 
        version: "v1", 
        endpoint: "Role/{id}", 
        requireAuthorization: true, 
        roles: new string[] { })]
    public class Handler
        (IRoleRepository repository)
        : UpdateRequest.Handler<Query, Domain.Models.Identity.Role, RoleDto, IRoleRepository>(repository)
    {
    }
}