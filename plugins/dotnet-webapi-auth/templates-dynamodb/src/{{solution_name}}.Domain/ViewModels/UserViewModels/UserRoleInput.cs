using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.UserViewModels;
public record UserRoleInput(string Id, string RoleId) : InputDto(Id);