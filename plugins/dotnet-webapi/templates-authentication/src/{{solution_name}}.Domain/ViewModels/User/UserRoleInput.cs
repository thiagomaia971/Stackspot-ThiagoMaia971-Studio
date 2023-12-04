using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.User;
public record UserRoleInput(string Id, string RoleId) : InputDto(Id);