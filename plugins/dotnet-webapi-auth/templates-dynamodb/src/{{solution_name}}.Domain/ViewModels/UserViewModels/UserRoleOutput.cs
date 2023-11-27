using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.UserViewModels;
public record UserRoleOutput(
    string Id,
    string CreatedAt, 
    string UpdatedAt, 
    string RoleId) : OutputDto(Id, CreatedAt, UpdatedAt);