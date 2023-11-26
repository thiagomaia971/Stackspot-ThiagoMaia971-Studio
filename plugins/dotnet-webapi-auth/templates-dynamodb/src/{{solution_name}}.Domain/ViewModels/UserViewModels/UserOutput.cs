using CruderSimple.Core.ViewModels;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Domain.ViewModels.UserViewModels;

public record UserOutput(
    string Id, 
    string CreatedAt, 
    string UpdatedAt,
    string Email,
    string Nome,
    string Username,
    bool EmailConfirmed,
    string PhoneNumber,
    bool PhoneNumberConfirmed,
    bool TwoFactorEnabled,
    List<UserRole> Roles) : OutputDto(Id, CreatedAt, UpdatedAt);