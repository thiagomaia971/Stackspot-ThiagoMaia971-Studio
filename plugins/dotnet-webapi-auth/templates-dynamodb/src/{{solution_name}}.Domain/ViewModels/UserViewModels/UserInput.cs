using System.ComponentModel.DataAnnotations;
using CruderSimple.Core.ViewModels;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Domain.ViewModels.UserViewModels;

public record UserInput(
    string Id,
    [Required] [EmailAddress] string Email,
    [Required] [DataType(DataType.Password)] string Password,
    [Required] string Name,
    bool EmailConfirmed,
    string PhoneNumber,
    bool PhoneNumberConfirmed,
    bool TwoFactorEnabled,
    List<UserRoleInput> Roles) : InputDto(Id);