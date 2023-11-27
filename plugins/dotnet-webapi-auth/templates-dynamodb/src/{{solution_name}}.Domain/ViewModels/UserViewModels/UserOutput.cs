using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.UserViewModels;

public record UserOutput(
    string Id, 
    string CreatedAt, 
    string UpdatedAt,
    string Email,
    string Name,
    bool EmailConfirmed,
    string PhoneNumber,
    bool PhoneNumberConfirmed,
    bool TwoFactorEnabled,
    ICollection<UserRoleOutput> Roles) : OutputDto(Id, CreatedAt, UpdatedAt);