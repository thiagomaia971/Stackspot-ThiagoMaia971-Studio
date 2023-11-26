using System.ComponentModel.DataAnnotations;
using CruderSimple.Core.ViewModels;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Domain.ViewModels.UserViewModels;

public class UserInput : InputDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public string Username { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }
    public List<UserRole> Usuarios { get; set; }
}