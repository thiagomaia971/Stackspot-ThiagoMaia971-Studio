using System.ComponentModel.DataAnnotations;
using CruderSimple.Core.ViewModels;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Domain.ViewModels.UserViewModels;

public record UserInput(
    string id,
    [Required] [EmailAddress] string Email,
    [Required] [DataType(DataType.Password)] string Password,
    [Required] string Nome,
    [Required] string Username,
    bool EmailConfirmed,
    string PhoneNumber,
    bool PhoneNumberConfirmed,
    bool TwoFactorEnabled,
    List<UserRole> Usuarios) : InputDto(id);