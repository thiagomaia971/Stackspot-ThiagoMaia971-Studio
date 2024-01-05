using System.ComponentModel.DataAnnotations;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public record UserDto(
    string Id,
    string {{multitenant_name}}Id,
    [Required] [EmailAddress] string Email,
    [Required] [DataType(DataType.Password)] string Password,
    [Required] string Name,
    bool EmailConfirmed,
    string PhoneNumber,
    bool PhoneNumberConfirmed,
    bool TwoFactorEnabled,
    List<UserRoleDto> Roles) : {{multitenant_name}}EntityInput(Id, {{multitenant_name}}Id);