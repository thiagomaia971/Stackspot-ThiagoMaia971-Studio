using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;
public record UserRoleDto(string Id, string RoleId) : InputDto(Id);