using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.User;
public record UserRoleOutput(
    string Id,
    string CreatedAt, 
    string UpdatedAt, 
    string RoleId) : OutputDto(Id, CreatedAt, UpdatedAt);