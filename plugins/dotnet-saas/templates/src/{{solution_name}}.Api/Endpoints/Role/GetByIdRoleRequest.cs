using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Role;

public static class GetByIdRoleRequest
{
    public record Query([FromRoute] string id) : GetByIdRequest.Query(id);

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "Role/{id}", 
        requireAuthorization: true, 
        new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (IMultiTenantRepository<Domain.Models.Identity.Role> repository)
        : GetByIdRequest.Handler<Query, Domain.Models.Identity.Role, RoleDto, IMultiTenantRepository<Domain.Models.Identity.Role>>(repository)
    {
    }
}