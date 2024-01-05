using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.MySql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Role;

public static class CreateRoleRequest
{
    public record Query([FromBody] RoleDto payload) : CreateRequest.Query<RoleDto>(payload);

    [EndpointRequest(
        method: EndpointMethod.POST, 
        version: "v1", 
        endpoint: "Role", 
        requireAuthorization: true, 
        new string[] {  })]
    public class Handler
        (
            IMultiTenantRepository<Domain.Models.Identity.Role> repository
        )
        : CreateRequest.Handler<Query, Domain.Models.Identity.Role, RoleDto, IMultiTenantRepository<Domain.Models.Identity.Role>>(repository)
    {
    }
}